using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.BLL.Services;
using memeApp.DAL.Repository;
using memeApp.BLL.Exceptions;
using memeApp.BLL.DTO;
using memeApp.DAL.Model;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using AutoMapper;
using memeApp.DAL;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace memeApp.BLL.Implementations
{
    public class UploadService : IMemeTemplateUpload
    { 
        private readonly IUnitofWork unitofWork;
        private readonly IWebHostEnvironment webHost;
        private readonly ILogger<MemeTemplateUpload> logger;
        private readonly IMapper mapper;
        private readonly IDistributedCache cache;
        private const string cacheKey = "Memes";
        public UploadService(IUnitofWork unitofWork, IWebHostEnvironment webHost, IMapper mapper, IDistributedCache cache, ILogger<MemeTemplateUpload> logger)
        {
            this.unitofWork = unitofWork;
            this.webHost = webHost;
            this.mapper = mapper;
            this.cache = cache;
            this.logger = logger;

        }
        public async Task<ApiResponse> GetMeme(Guid Id)
        {
            var get_Meme = await unitofWork.uploadRepository.Get(Id);
            if (get_Meme == null)
            {
                throw new NotFoundException($"Meme of this {Id} does not exist");
            }
            return new ApiResponse(200, "Meme found ", get_Meme);
        }
        public async Task<PagedResponse> GetPagedData(PaginationFiltersDTO paginationFilters)
        {
            try
            {
                var filter = mapper.Map<PaginationFilters>(paginationFilters);
                var count_Records = await unitofWork.uploadRepository.GetMemeCount();
                var totalPages=(int)Math.Ceiling(count_Records/(decimal)filter.PageSize);
                var result = await unitofWork.uploadRepository.GetPagedData(filter);
                return new PagedResponse(200, "data displayed successfully", result, filter.PageNumber, filter.PageSize, totalPages, 
                 count_Records);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ApiResponse> GetMeme()
        {
            List<MemeTemplateUpload> memes = new List<MemeTemplateUpload>();
            var cachedData = await cache.GetAsync(cacheKey);
            //if cachedata is null , fetch the data from the database then populate it into our caching mechanism.
            if (cachedData == null)
            {
                logger.LogInformation("Fetching data from the database and populating cache");
                memes = await unitofWork.uploadRepository.GetAll();
                var cacheDataString = JsonConvert.SerializeObject(memes);
                var cacheDataBytes = Encoding.UTF8.GetBytes(cacheDataString);
                var caching = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));
                await cache.SetAsync(cacheKey, cacheDataBytes, caching);
            }
            else
            {
                logger.LogInformation("Fetching data from the cache redis cache");
                //if cache data is available then deserialize the data and show the records from the cache.
                var stringCachedData = Encoding.UTF8.GetString(cachedData);
                memes= JsonConvert.DeserializeObject<List<MemeTemplateUpload>>(stringCachedData);
            }
            return new ApiResponse(200, "Meme Displayed successfully", memes);


        }
    



        public async Task<IActionResult> AddMeme(UploadDTO upload)
        {
            try
            {
                var path = webHost.WebRootPath;
                var filePath = "Content/Files/" + upload.fileData.FileName;
                var fullPath = Path.Combine(path, filePath);

                await upload.fileData.CopyToAsync(new FileStream(fullPath, FileMode.Create));

                var memes = new MemeTemplateUpload()
                {
                    Name = upload.Name,
                    Type = upload.Type,
                    Keyword = upload.Keyword,
                    UploadDate = DateTime.Now,
                    Path = filePath,
                    usersId = upload.UserId,
                    //fileData = await ReadFile(upload.fileData)

                    //await unitofWork.userRepository.FindUserByName(upload.UserName)


                };
                await unitofWork.uploadRepository.Post(memes);
                await unitofWork.Save();
                return new OkObjectResult(new ApiResponse(200, "Meme added successfully", memes));



                // Set the status code in the response



            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.ToString());
            }

        }


        public async Task<ApiResponse> DeleteMeme(Guid id)
        {
            try
            {
                var delete_Meme = await unitofWork.uploadRepository.Delete(id);
                await unitofWork.Save();
                return new ApiResponse(200, $"Meme of id= {id} is deleted successfully", delete_Meme);

            }
            catch (Exception ex)
            {
                throw new NotFoundException(ex.Message);
            }

        }
        public async Task<ApiResponse> DeleteAllMemes()
        {
            try
            {
                var delete_Memes = await unitofWork.uploadRepository.RemoveAllMemes();
                await unitofWork.Save();
                return new ApiResponse(200, "All meme deleted successfully", delete_Memes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public async Task<byte[]> ReadFile(IFormFile file)
        //{
        //    using (var stream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(stream);
        //        return stream.ToArray();

        //    }

        //}
    
        
    }
}
