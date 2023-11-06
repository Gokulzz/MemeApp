using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using memeApp.BLL.DTO;
using Microsoft.AspNetCore.Http;

namespace memeApp.BLL.Services
{
    public interface IUserService
    {
        public Task<ApiResponse> GetAllUser();
        public Task<ApiResponse> GetUser(Guid Id);
        public Task<ApiResponse> AddUser(UserDTO userDTO);
        public Task<ApiResponse> UpdateUser(Guid Id, UserDTO userDTO);
        public Task<ApiResponse> DeleteUser(Guid Id);
        public Task<ApiResponse> VerifyUser(Guid VerificationToken);
        public Task<ApiResponse> LoginUser(UserLoginDTO userLogin);
        public Guid GetCurrentId();
        //public Task<Guid> FindUserbyName(string Name);
    }
}
