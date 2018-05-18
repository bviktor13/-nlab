using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MyWebAppDal.DTO;

namespace MyWebAppDal.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Image { get; set; }
        public DateTime BirthDate { get; set; }
        public string FullName { get; set; }
        public List<HouseDto> MyHouses { get; set; }
        public List<FavouriteDto> Favourites { get; set; }

    }
}
