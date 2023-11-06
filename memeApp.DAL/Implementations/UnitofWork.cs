using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Data;
using memeApp.DAL.Model;
using memeApp.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace memeApp.DAL.Implementations
{
    public class UnitofWork : IUnitofWork
    {
        public readonly DataContext dataContext;
        public IUserRepository userRepository { get; }
        public IUserRoleRepository userRoleRepository { get; }
        public IUploadRepository uploadRepository { get; }
        public IDownloadRepository downloadRepository { get; }
        public IUserDownloadRepository userDownloadRepository { get; }
     
        public UnitofWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
            userRepository = new UserRepository(dataContext);
            userRoleRepository = new UserRoleRepository(dataContext);
            uploadRepository = new UploadRepository(dataContext);
            downloadRepository = new DownloadRepository(dataContext);
            userDownloadRepository= new UserDownloadRepository(dataContext);
           
        }
        public async Task Save()
        {
            await dataContext.SaveChangesAsync();
        }
        public async Task<User> FindUserByEmail(string email)
        {
            //we are retrieving the user of same email and also retreiving the role assigned to that user.
            var user = await dataContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            var roles = await userRoleRepository.Get(user.userRoleRoleId);
            user.RoleName = roles.Role_Name;
            return user;

        }
        //public async Task<Guid> FindByUserName(string userName)
        //{

        //    var search_User = await dataContext.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        //    var user = await userRepository.Get(search_User.Id);
        //    return user.Id;
        //}

    }





}