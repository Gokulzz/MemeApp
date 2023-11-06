using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace memeApp.BLL.Services
{
    public interface IMemeTemplateUpload
    {
        public Task<ApiResponse> GetMeme(Guid id);
        public Task<PagedResponse> GetPagedData(PaginationFiltersDTO paginationFilters);
        public Task<ApiResponse> GetMeme();
        public Task<ApiResponse> GetMemeByName(string name);
        public Task<IActionResult> AddMeme(UploadDTO upload);
        public Task<ApiResponse> DeleteMeme(Guid id);
        public Task<ApiResponse> DeleteAllMemes();
        
    }
}
