using MyWebAppDal.DTO;
using MyWebAppDal.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models.SearchViewModels
{
    public class SearchHousesViewModels
    {
        public PagingList<HouseDto> Houses { get; set; }
        public HouseSearchDto Search { get; set; }
    }
}
