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
    public class DownloadRepository : GenericRepository<MemeTemplateDownload>, IDownloadRepository
    {
        public DownloadRepository(DataContext dataContext) : base(dataContext)
        {
        
        }
        
       
    }
}
