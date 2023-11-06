using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using memeApp.BLL.DTO;
using memeApp.BLL.Exceptions;
using memeApp.BLL.Services;
using memeApp.DAL.Model;
using memeApp.DAL.Repository;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace memeApp.BLL.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;
        public RoleService(IUnitofWork unitofWork, IMapper mapper) 
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;   
        }
        public async Task<ApiResponse> GetAllRole()
        {
            try
            {
                var get_Users = await unitofWork.userRoleRepository.GetAll();
                return new ApiResponse(200, "Users displayed successfully", get_Users);
            }
            catch(Exception ex)  
            {
                throw new BadRequestException(ex.Message);
            }
        }
        public async Task<ApiResponse> GetRole(Guid Id)
        {
            try
            {
                var get_user = await unitofWork.userRoleRepository.Get(Id);
                return new ApiResponse(200, $"User of {Id} displayed successfully", get_user);
            }
            catch(Exception ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }
        public async Task<ApiResponse> AddRole(RoleDTO roleDTO)
        {
            try
            {
                var map_Roles = mapper.Map<UserRole>(roleDTO);
                await unitofWork.userRoleRepository.Post(map_Roles);
                await unitofWork.Save();
                return new ApiResponse(200, "New Role added successfully", map_Roles);
            }
            catch(Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
            
        }
        public async Task<ApiResponse> UpdateRole(Guid id,RoleDTO roleDTO)
        {
            try
            {
                var find_Role = await unitofWork.userRoleRepository.Get(id);
                if (find_Role == null)
                {
                    throw new Exception();
                }
                find_Role.Role_Name = roleDTO.Role_Name;
                find_Role.Role_Description = roleDTO.Role_Description;
                await unitofWork.userRoleRepository.Update(find_Role);
                await unitofWork.Save();
                return new ApiResponse(200, $"Role of {id} updated successfully", find_Role);
            }
            catch(Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteRole(Guid id)
        {
            try
            {
                var delete_Role = await unitofWork.userRoleRepository.Delete(id);
                await unitofWork.Save();
                return new ApiResponse(200, $"Role of id= {id} is deleted successfully", delete_Role);
            }
            catch(Exception ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }
       
    }
}
