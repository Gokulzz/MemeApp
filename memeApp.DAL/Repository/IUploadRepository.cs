using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Model;

namespace memeApp.DAL.Repository
{
    public interface IUploadRepository : IGenericRepository<MemeTemplateUpload>
    {
        public Task<List<MemeTemplateUpload>> RemoveAllMemes();
        public Task<int> GetMemeCount();    
        public Task<List<MemeTemplateUpload>> GetPagedData(PaginationFilters paginationFilters);

    }
   
}
