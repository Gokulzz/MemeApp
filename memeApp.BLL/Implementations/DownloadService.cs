using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.BLL.Services;
using memeApp.DAL.Repository;
using memeApp.BLL.Exceptions;
using memeApp.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace memeApp.BLL.Implementations
{
    public class DownloadService: IMemeTemplateDownload
    {
        private readonly IUnitofWork unitofWork;
        private readonly IWebHostEnvironment webHost;
        private readonly IUserService userService;
        public DownloadService(IUnitofWork unitofWork, IWebHostEnvironment webHost, IUserService userService)
        {
            this.unitofWork = unitofWork;
            this.webHost = webHost;
            this.userService = userService; 
        }
        public async Task<ApiResponse> DownloadMeme(Guid id)
        {
            try
            {
                Guid userId =  userService.GetCurrentId();
                var webPath = webHost.WebRootPath;
                var search_Meme = await unitofWork.uploadRepository.Get(id);
                if (search_Meme == null)
                {
                    throw new NotFoundException($"Meme of {id} was not found");
                }
                var filePath = search_Meme.Path;
                var fullPath= Path.Combine(webPath, filePath);  
                byte[] fileData =await ReadFile(fullPath);
                //creating a memory stream using the contents of file and reading the file from the memory
                var content = new MemoryStream(fileData);
                string originalExtension = Path.GetExtension(filePath).ToLowerInvariant();
                var downloadDirectory = @"C:\DownloadedFiles";
                Directory.CreateDirectory(downloadDirectory);
                var path = Path.Combine(
                downloadDirectory,$"{search_Meme.Name}.{originalExtension}");
                await CopyStream(content, path);
                var add_Data = new MemeTemplateDownload()
                {
                    Name = search_Meme.Name,
                    Keyword = search_Meme.Keyword,
                    DownloadDate = DateTime.Now,
                    UploadsUploadID = search_Meme.UploadID


                };
                
                var add_UserDownload = new UserDownloadMeme()
                {
                    memeTemplateDownloadsDownloadId = add_Data.DownloadId,
                    usersId = userId


                };
               

                await unitofWork.downloadRepository.Post(add_Data);
                
                await unitofWork.userDownloadRepository.Post(add_UserDownload);
                await unitofWork.Save();
                return new ApiResponse(200, "File downloaded successfully", add_Data);
                

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.ToString());
            }

        }
        public async Task<ApiResponse> DownloadMeme(string keyword)
        {
            throw new NotImplementedException();
        }
        public async Task<ApiResponse> DeleteMeme(Guid id)
        {
            var delete_Meme = await unitofWork.downloadRepository.Delete(id);
            if (delete_Meme == null)
            {
                throw new NotFoundException($"Meme of this id {id} could not be found");
            }
            await unitofWork.Save();
            return new ApiResponse(200, "Meme deleted successfully", delete_Meme);
        }
        public async Task<byte[]> ReadFile(string filePath)
        {
            using(var filestream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var stream = new MemoryStream())
                {
                    await filestream.CopyToAsync(stream);
                    return stream.ToArray();

                }

            }
           

        }
        
        public async Task CopyStream(Stream stream, string path)
        {
            //writing the content of the stream to the file in specified path
            using (var filestream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(filestream);
            }
        }
    }
}
