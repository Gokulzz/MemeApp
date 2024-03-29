﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memeApp.DAL.Model
{
    public class PaginationFilters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }   
        public int TotalPages { get; set; }
        public PaginationFilters()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PaginationFilters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 10 ? pageSize : 10;
        }


    }
}
