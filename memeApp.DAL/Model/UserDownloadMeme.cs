using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memeApp.DAL.Model
{
    public class UserDownloadMeme
    {
        public Guid memeTemplateDownloadsDownloadId { get; set; }   
        public Guid usersId { get; set; }   
    }
}
