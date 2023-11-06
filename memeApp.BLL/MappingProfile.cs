using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using memeApp.BLL.DTO;
using memeApp.DAL.Model;

namespace memeApp.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoleDTO, UserRole>();
            CreateMap<PaginationFiltersDTO, PaginationFilters>();
        }

    }
}
