using MyWebAppDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebAppDal.DTO;

namespace MyWebApp.Models.HomeViewModels
{
    public class HouseDetailsView
    {
        public HouseDetailsDto HouseDetails { get; set; }
        public CityDto City { get; set; }

    }
}
