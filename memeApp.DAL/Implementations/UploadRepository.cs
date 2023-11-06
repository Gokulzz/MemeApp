using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Data;
using memeApp.DAL.Model;
using memeApp.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace memeApp.DAL.Implementations
{
    public class UploadRepository : GenericRepository<MemeTemplateUpload>, IUploadRepository
    {
        public UploadRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public async Task<List<MemeTemplateUpload>> RemoveAllMemes()
        {
            var data = await dataContext.UploadMeme.ToListAsync();
            dataContext.UploadMeme.RemoveRange(data);
            return data;
        }
        public async Task<int> GetMemeCount()
        {
            var memes = dataContext.UploadMeme.Count();
            return memes;
        }
        public async Task<List<MemeTemplateUpload>> GetPagedData(PaginationFilters paginationFilters)
        {
            var validFilters = new PaginationFilters(paginationFilters.PageNumber, paginationFilters.PageSize);
            var pagedData = await dataContext.UploadMeme.Skip((validFilters.PageNumber - 1) * validFilters.PageSize).
                Take(validFilters.PageSize)
                .ToListAsync();
            return pagedData;
        }
        public async Task<MemeTemplateUpload> GetMemeByName(string name)
        { 
            var meme_Name= await dataContext.UploadMeme.Where(x=>x.Name.ToLower().Equals(name.Trim().ToLower())).FirstOrDefaultAsync();
            return meme_Name;
        }
    }
}
