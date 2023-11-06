using memeApp.BLL;
using memeApp.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace memeApp.PL.Controllers
{
    [Authorize(Roles ="Admin, Normal User" )]

    public class DownloadController : Controller
    {
       
        private readonly IMemeTemplateDownload download;
        public DownloadController(IMemeTemplateDownload download)
        {
            this.download = download;
        }
        [HttpGet("DownloadById")]
        public async Task<ApiResponse> DownloadById(Guid id)
        {
            var find_Id = await download.DownloadMeme(id);
            return find_Id;
        }
        [HttpDelete("DeleteMemeById")]
        public async Task<ApiResponse> DeleteMemeById(Guid id)
        {
            var delete_Meme= await download.DeleteMeme(id);
            return delete_Meme;
        }

    }
}
