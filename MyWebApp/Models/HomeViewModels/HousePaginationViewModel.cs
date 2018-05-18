using MyWebAppDal.Models;
using System.Collections.Generic;
using MyWebAppDal.DTO;
using System.Linq;
using ReflectionIT.Mvc.Paging;

namespace MyWebApp.Models.HomeViewModels
{
    public class HousePaginationViewModel
    {
        public IEnumerable<CityDto> Cities { get; set; }
        public PagingList<HouseDto> Houses { get; set; }
        public HouseSearchDto HouseSearch { get; set; }

    }
}
