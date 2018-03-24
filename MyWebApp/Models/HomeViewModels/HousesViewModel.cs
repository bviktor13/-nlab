using MyWebAppDal.Model;
using MyWebAppDal.Repository;
using System;
using System.Collections.Generic;
using MyWebAppDal.DTO;
using System.Linq;
using System.Threading.Tasks;
using PagedList;

namespace MyWebApp.Models.HomeViewModels
{
    public class HousesViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<HouseDto> Houses { get; set; }
        public HouseSearch HouseSearch { get; set; }

    }
}
