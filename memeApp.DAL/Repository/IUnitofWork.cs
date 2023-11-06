using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Implementations;
using memeApp.DAL.Model;

namespace memeApp.DAL.Repository
{
    public interface IUnitofWork
    {
        public IUserRepository userRepository { get; }
        public IUserRoleRepository userRoleRepository { get; }
        public IUploadRepository uploadRepository { get; }   
        public IDownloadRepository downloadRepository { get; }
        public IUserDownloadRepository userDownloadRepository { get; }
        public  Task Save();
        public  Task<User> FindUserByEmail(string email);
        //public Task<Guid> FindByUserName(string userName);
    }
    
}
