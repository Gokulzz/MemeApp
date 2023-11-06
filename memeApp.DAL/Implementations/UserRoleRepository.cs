using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Data;
using memeApp.DAL.Model;
using memeApp.DAL.Repository;

namespace memeApp.DAL.Implementations
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
