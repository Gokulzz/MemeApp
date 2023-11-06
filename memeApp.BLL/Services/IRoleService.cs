using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using memeApp.BLL.DTO;

namespace memeApp.BLL.Services
{
    public interface IRoleService
    {
        public Task<ApiResponse> GetAllRole();
        public Task<ApiResponse> GetRole(Guid Id);
        public Task<ApiResponse> AddRole(RoleDTO roleDTO);
        public Task<ApiResponse> UpdateRole(Guid Id, RoleDTO roleDTO);
        public Task<ApiResponse> DeleteRole(Guid Id);
    }
}
