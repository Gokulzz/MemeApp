using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace memeApp.BLL.DTO
{
     public class RoleDTO
     {
        public Guid RoleId { get; set; }
        public string Role_Name { get; set; }
        public string Role_Description { get; set; }
     }
} 
