using System.Reflection.Metadata.Ecma335;
using memeApp.BLL;
using memeApp.BLL.DTO;
using memeApp.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace memeApp.PL.Controllers
{
    [Authorize(Roles = "Admin, Normal User")]
    public class UploadController : Controller
    {
       
       public IMemeTemplateUpload uploadservice { get; set; }   
        public UploadController(IMemeTemplateUpload uploadservice)
        {
            this.uploadservice = uploadservice;
        }
        [HttpGet("GetMemeById")]
        public async Task<ApiResponse> GetMeme(Guid Id)
        {
            var get_Meme= await uploadservice.GetMeme(Id);
            return get_Meme;
        }
        [HttpGet("GetMemes")]
        public async Task<ApiResponse> GetMemes()
        {
            var get_Memes = await uploadservice.GetMeme();
            return get_Memes;
        }
        [HttpGet("GetMemeByName")]
        public async Task<ApiResponse> GetMemeByName(string name)
        {
            var get_Meme = await uploadservice.GetMemeByName(name);
            return get_Meme;
        }

        [HttpGet("GetPagedMeme")]
        public async Task<PagedResponse> GetPagedMeme(PaginationFiltersDTO paginationFilters)
        {
            var get_pagedMeme= await uploadservice.GetPagedData(paginationFilters); 
            return get_pagedMeme;
        }

        [HttpPost("PostMeme")]
        public async Task<IActionResult> PostMeme(UploadDTO uploadDTO)
        {
            var add_Meme = await uploadservice.AddMeme(uploadDTO);
            return add_Meme;    
        }
        [HttpDelete("RemoveMeme")]
        public async Task<ApiResponse> RemoveMeme(Guid id)
        {
            var delete_Meme = await uploadservice.DeleteMeme(id);
            return delete_Meme; 
        }
        [HttpDelete("RemoveAllMemes")]
        public async Task<ApiResponse> RemovaAllMemes()
        {
            var remove_Memes = await uploadservice.DeleteAllMemes();
            return remove_Memes;
        }
    }
}
