using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memeApp.DAL.Model
{
    public class User
    {
        [Key]
        public Guid Id  = Guid.NewGuid();   
        public string Email { get; set; }   
        public byte[] PasswordHash { get; set; }    
        public byte[] PasswordSalt { get; set; }
        public string UserName { get; set; }    
        public Guid VerificationToken { get; set; } 
        public DateTime? VerifiedAt { get; set; }    
        public UserRole userRole { get; set; }  
        public Guid userRoleRoleId { get; set; }    
        public ICollection<MemeTemplateDownload>? memeTemplateDownloads { get; set; } 
        public ICollection<MemeTemplateUpload>? memeTemplateUploads { get;set; }
        
        public string? RoleName { get; set; }   

    }
}
