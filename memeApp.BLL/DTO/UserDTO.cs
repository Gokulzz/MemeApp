using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memeApp.BLL.DTO
{
    public class UserDTO
    { 
        
        public Guid  userID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public Guid RoleId { get; set; }
        
        public UserDTO(string Email, string Password, string ConfirmPassword, string UserName) 
        {
            this.Email = Email;
            this.Password = Password;
            this.ConfirmPassword = ConfirmPassword;
            this.UserName = UserName;

        }
        

    }
}
