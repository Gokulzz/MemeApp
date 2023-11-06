using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace memeApp.DAL.Model
{
    public enum FileType
    {
        Image,
        Video
    }
    public class MemeTemplateUpload
    {
      
        public Guid UploadID = Guid.NewGuid();  
        public string Name { get; set; }    
        public FileType Type { get; set; }    
        public string Path { get; set; }    
        public string Keyword { get; set; } 
        public User Users { get; set; }
        public Guid usersId { get; set; }   
        public DateTime UploadDate { get; set; } 
        public ICollection<MemeTemplateDownload>? Downloads { get; set; }


    }
}
