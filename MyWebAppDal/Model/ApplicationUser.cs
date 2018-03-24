using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyWebAppDal.Model;

namespace MyWebAppDal.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Image { get; set; }
        public DateTime BirthDate { get; set; }
        public string FullName { get; set; }

       // private IEnumerable<Favourite> Favourites { get; set; } //ICollection
       // private IList<House> MyHouses { get; set; }

    }
}
