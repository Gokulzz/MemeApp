using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Model;

namespace memeApp.DAL.Repository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        public Task<User> VerifyUser(Guid Token);
        //public Task<Guid> FindUserByName(string Name);
    

    }
}
