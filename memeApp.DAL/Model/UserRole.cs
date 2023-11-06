using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace memeApp.DAL.Model
{
    public class UserRole
    {
        public Guid RoleId = Guid.NewGuid();   
        public string Role_Name { get; set; }   
        public string Role_Description { get; set; }
        public ICollection<User> users { get; set; }

    }
}
