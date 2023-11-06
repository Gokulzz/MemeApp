using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Data;
using memeApp.DAL.Model;
using memeApp.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace memeApp.DAL.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public async Task<User> VerifyUser(Guid Token)
        {
            var find_Token = await dataContext.Users.Where(x => x.VerificationToken == Token).FirstOrDefaultAsync();
            return find_Token;
        }
        /*public async Task<Guid> FindUserByName(string Name)
        {
            var find_User = await dataContext.Users.Where(x=>x.UserName== Name).FirstOrDefaultAsync();
            return find_User.Id;
            
        }*/
       
    }
}
