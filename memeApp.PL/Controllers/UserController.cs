using memeApp.BLL.DTO;
using memeApp.BLL;
using memeApp.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace memeApp.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        public IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("GetUser")]
        public async Task<ApiResponse> GetUser(Guid id)
        {
            var getUser = await userService.GetUser(id);
            return getUser;
        }
        [HttpGet("GetAllUser")]
        public async Task<ApiResponse> GetAllUser()
        {
            var getUsers = await userService.GetAllUser();
            return getUsers;
        }
        [HttpPost("AddUser")]
        public async Task<ApiResponse> AddUsers(UserDTO user)
        {
            var addUser = await userService.AddUser(user);
            return addUser;
        }
        [HttpPut("UpdateUsers")]
        public async Task<ApiResponse> UpdateUsers(Guid Id, UserDTO user)
        {
            var update_User = await userService.UpdateUser(Id, user);
            return update_User;
        }
        [HttpDelete("DeleteUsers")]
        public async Task<ApiResponse> DeleteUsers(Guid id)
        {
            var delete_User = await userService.DeleteUser(id);
            return delete_User;
        }
        [HttpPost("VerifyUser")]
        public async Task<ApiResponse> VerifyUser(Guid token)
        {
            var verify_User= await userService.VerifyUser(token);
            return verify_User;
        }
    }
}
