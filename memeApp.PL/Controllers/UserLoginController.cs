using memeApp.BLL;
using memeApp.BLL.DTO;
using memeApp.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace memeApp.PL.Controllers
{
    public class UserLoginController : Controller
    {
        public IUserService userService;
        public UserLoginController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("UserLogin")]
        public async Task<ApiResponse> UserLogin(UserLoginDTO userLogin)
        {
            var login = await userService.LoginUser(userLogin);
            return login;
        }
    }
}
