using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memeApp.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Post(T entity);
        Task<T> Delete(Guid id);
        Task<T> Update(T entity);   

    }
}
