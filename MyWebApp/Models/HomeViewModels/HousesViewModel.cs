﻿using MyWebAppDal.Models;
using MyWebAppDal.Repository;
using System;
using System.Collections.Generic;
using MyWebAppDal.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models.HomeViewModels
{
    public class HousesViewModel
    {
        public IEnumerable<CityDto> Cities { get; set; }
        public IEnumerable<HouseDto> Houses { get; set; }
        public HouseSearchDto HouseSearch { get; set; }

    }
}
