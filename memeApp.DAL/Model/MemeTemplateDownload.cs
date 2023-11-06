using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace memeApp.DAL.Model
{
    public class MemeTemplateDownload
    {
        [Key]
        public Guid DownloadId= Guid.NewGuid();
        public string Name { get; set; }
        public string Keyword { get; set; }
        public DateTime DownloadDate { get; set; }
        public Guid UploadsUploadID { get; set; }  
        public ICollection<User>? users { get; set; }
        public MemeTemplateUpload Uploads { get; set; }  
        
    }
}
