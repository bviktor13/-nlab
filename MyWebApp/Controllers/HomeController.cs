using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Models.HomeViewModels;
using MyWebAppDal.Model;
using MyWebAppDal.Models;
using MyWebAppDal.Repository;
using PagedList;
using ReflectionIT.Mvc.Paging;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           

            return View();
        }

        public IActionResult Advertisement()
        {
            ViewData["Message"] = "Hirdetes feladása vagy törlése";

            var repo = new Repo();
            AddHouseViewModel newHouse = new AddHouseViewModel();

            //newHouse.Cities = repo.GetCities();
            newHouse.House = new House();


            return View(newHouse);
        }

        [HttpPost]
        public ActionResult Save(House house)
        {
            var repo = new Repo();

            if (!ModelState.IsValid)
            {

                var newHouse = new AddHouseViewModel
                {
                    House = house,
                   // Cities = repo.GetCities()
                };
                return View("Advertisement", newHouse);
            }
            /*  if (house.Id == 0)
              {
                  repo.context().Houses.Add(house);      
              }
              else
              {
                  var DbHouses = repo.context().Houses.Single(h => h.Id == house.Id);*/
            var dbHouses = repo.context().Houses.Single(h => h.Id == house.Id);
                  dbHouses.Price = house.Price;
                  dbHouses.Animal = house.Animal;
                  dbHouses.Area = house.Area;
                  dbHouses.Balcony = house.Balcony;
                  dbHouses.CityId = house.CityId;
                  dbHouses.Details = house.Details;
                  dbHouses.Elevator = house.Elevator;
                  dbHouses.Image = house.Image;
                  dbHouses.InnerHeightType = house.InnerHeightType;
                  dbHouses.RoomNumber = house.RoomNumber;
                  dbHouses.PartyRoomNumber = house.PartyRoomNumber;
                  dbHouses.HouseType = house.HouseType;
                  dbHouses.HeatingType = house.HeatingType;
                  dbHouses.ForSaleType = house.ForSaleType;
                  dbHouses.Furnished = house.Furnished;
                  dbHouses.HouseNumber = house.HouseNumber;
                  dbHouses.Street = house.Street;
                  dbHouses.Smoking = house.Smoking;
              /*}*/
            repo.context().Houses.Add(dbHouses);

            repo.context().SaveChanges();

            return RedirectToAction("Houses", "Home");
        }

        public IActionResult Favourite()
        {
            ViewData["Message"] = "A kedvenceid.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Houses()
        {
            HousesViewModel houses = new HousesViewModel();

            var repo = new Repo();

            houses.Houses = repo.GetHouses();
            houses.Cities = repo.GetCities();
            houses.HouseSearch = new HouseSearch();
            /*var count = houses.Houses.Count();
            houses.Houses.Skip(page * PageSize).Take(PageSize).ToList();
            this.ViewBag.MaxPage =  (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            this.ViewBag.Page = page;*/

            return View(houses);
        }

        public IActionResult HouseDetails(int id)
        {

            var repo = new Repo();
            House housedetail = repo.HouseById(id);

            return View(housedetail);
        }

        public IActionResult GetHouses(int page = 1)
        {

            var repo = new Repo();
            List<House> houses;
            houses = repo.GetMyHouses();
            int pageSize = 1;
            int pageNumber = 1;

            return View(houses.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult UserDetails(string id)
        {

            var repo = new Repo();
            ApplicationUser userdetails = repo.UserById(id);

            return View(userdetails);

        }

        /*public async Task<IActionResult> Myhouses(int page = 1)
        {
            var repo = new Repo();
            var houses = repo.GetHouses().OrderBy(h => h.Id);
            //var model = await PagingList.CreateAsync(houses, 2, page);

           // return View(model);
        }*/
    }
}
