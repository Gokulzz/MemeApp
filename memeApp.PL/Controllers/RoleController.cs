using memeApp.BLL;
using memeApp.BLL.DTO;
using memeApp.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace memeApp.PL.Controllers
{
    public class RoleController : Controller
    {
        public IRoleService service;
        public RoleController(IRoleService service)
        {
            this.service = service;
        }
        [HttpGet("GetRoleById")]
       
        public async Task<ApiResponse> GetRoleById(Guid id)
        {
            var getRole = await service.GetRole(id);
            return getRole;
        }
        [HttpGet("GetAllRoles")]
        public async Task<ApiResponse> GetAllUser()
        {
            var getRoles = await service.GetAllRole();
            return getRoles;
        }
        [HttpPost("AddRoles")]
        public async Task<ApiResponse> AddRoles(RoleDTO userRole)
        {
            var addUserRoles = await service.AddRole(userRole);
            return addUserRoles;
        }
        [HttpPut("UpdateUserRoles")]
        public async Task<ApiResponse> UpdateUserRoles(Guid id, RoleDTO user)
        {
            var update_UserRoles = await service.UpdateRole(id,user);
            return update_UserRoles;
        }
        [HttpDelete("DeleteUserRoles")]
        public async Task<ApiResponse> DeleteUserRoles(Guid id)
        {
            var delete_UserRoles = await service.DeleteRole(id);
            return delete_UserRoles;
        }
    }
}

