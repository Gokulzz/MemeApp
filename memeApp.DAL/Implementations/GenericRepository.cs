using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Data;
using memeApp.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace memeApp.DAL.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DataContext dataContext;
        public GenericRepository(DataContext dataContext)
        {
         this.dataContext = dataContext;
        }
        public async Task<List<T>> GetAll()
        {
            var data = await dataContext.Set<T>().ToListAsync();
            return data;
        }
        public async Task<T> Get(Guid id)
        {
            var data= await dataContext.Set<T>().FindAsync(id);
            return data;
        }
        public async Task<T> Post(T entity)
        {
            var add_Data= await dataContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            var update_Data = dataContext.Set<T>().Update(entity);
            return entity;
        }
        public async Task<T> Delete(Guid id)
        {
            var find_Data = await dataContext.Set<T>().FindAsync(id);
            var delete_Data =  dataContext.Set<T>().Remove(find_Data);
            return find_Data;
        }
 
    }
}
