using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebAppDal.Model;
using MyWebAppDal.Models;

namespace MyWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private static DbContextOptions<ApplicationDbContext> _options;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :  base(options)
        {
            _options = options;
        }

        public ApplicationDbContext() : base(_options)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<HouseSearch> HouseSearches { get; set; }
    }
}
