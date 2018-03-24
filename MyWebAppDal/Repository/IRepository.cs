using MyWebApp.Data;
using MyWebAppDal.DTO;
using MyWebAppDal.Model;
using MyWebAppDal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebAppDal.Repository
{
    public interface IRepository
    {
        IEnumerable<HouseDto> GetHouses();

        List<House> GetMyHouses();

        IEnumerable<City> GetCities();

        House HouseById(int Id);

        ApplicationUser UserById(string id);
    }
}
