using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memeApp.BLL.Services
{
    public interface IMemeTemplateDownload
    {
        
        public Task<ApiResponse> DownloadMeme(Guid id);
        //public Task<ApiResponse> DownloadMeme(string keyword);
        public Task<ApiResponse> DeleteMeme(Guid id);   
    }
}
