using MyWebAppDal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models.HomeViewModels
{
    public class FavouritesViewModel
    {
        public IEnumerable<CityDto> Cities { get; set; }
        public IEnumerable<HouseDto> FavouriteHouses { get; set; }


    }
}
