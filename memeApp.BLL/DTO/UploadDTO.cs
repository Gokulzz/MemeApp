using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Model;
using Microsoft.AspNetCore.Http;

namespace memeApp.BLL.DTO
{
    public class UploadDTO
    {
        public string Name { get; set; }
        public FileType Type { get; set; }
        public IFormFile fileData { get; set; }
        public string Path { get; set; }    
        public string Keyword { get; set; }
        //public string UserName { get; set; }    
        public Guid UserId { get; set; }  
        public ICollection<MemeTemplateDownload>? Downloads { get; set; }
        

    }
}
