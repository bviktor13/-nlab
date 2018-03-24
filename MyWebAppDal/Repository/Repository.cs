﻿using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebAppDal.DTO;
using MyWebAppDal.Model;
using MyWebAppDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebAppDal.Repository
{
   public class Repository: IRepository
   {

        public IEnumerable<HouseDto> GetHouses()
        {

            using (var context = new ApplicationDbContext())
            {
                var houses = context.Houses.Select(h => new HouseDto
                {
                    Id = h.Id,
                    Price = h.Price,
                    CityId = h.CityId,
                    Street = h.Street,
                    HouseNumber = h.HouseNumber,
                    Area = h.Area,
                    RoomNumber = h.RoomNumber,
                    PartyRoomNumber = h.PartyRoomNumber,
                    Image = h.Image,
                }).ToList();
                return houses;
            }
        }

        public List<House> GetMyHouses()
        {

            int pageSize = 1;
            using (var context = new ApplicationDbContext())
            {
                int page = context.Houses.Count();
                var houses = context.Houses.OrderByDescending(h => h.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                return houses;
            }
        }


        public IEnumerable<City> GetCities()
        {
            using (var context = new ApplicationDbContext())
            {
                IEnumerable<City> cities = context.Cities.ToList();

                return cities;
            }
        }

        public House HouseById(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                House HouseById = context.Houses.Find(Id);


                return HouseById;
            }
        }

        public ApplicationUser UserById(string id)
        {

            using(var context = new ApplicationDbContext())
            {
                ApplicationUser applicationUser = context.Users.Find(id);

                return applicationUser;
            }
        }
    }
}

