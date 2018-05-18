using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebAppDal.DTO;
using MyWebAppDal.Models;

namespace MyWebApp.Models.AdvertisementViewModels
{
    public class AddHouseViewModel
    {
        public HouseDetailsDto House { get; set; }
        public IEnumerable<CityDto> Cities { get; set; }

        public List<HouseDto> UserHouses { get; set; }
    }
}
