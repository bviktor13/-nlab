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
using Sakura.AspNetCore;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Advertisement()
        {
            ViewData["Message"] = "Hirdetes feladása vagy törlése";

            AddHouseViewModel newHouse = new AddHouseViewModel();

            //newHouse.Cities = _repo.GetCities();
            newHouse.House = new House();


            return View(newHouse);
        }

        [HttpPost]
        public ActionResult Save(House house)
        {
            if (!ModelState.IsValid)
            {

                var newHouse = new AddHouseViewModel
                {
                    House = house,
                   // Cities = _repo.GetCities()
                };
                return View("Advertisement", newHouse);
            }
            /*  if (house.Id == 0)
              {
                  _repo.context().Houses.Add(house);      
              }
              else
              {
                  var DbHouses = _repo.context().Houses.Single(h => h.Id == house.Id);*/
            var dbHouses = _repo.context().Houses.Single(h => h.Id == house.Id);
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
            _repo.context().Houses.Add(dbHouses);

            _repo.context().SaveChanges();

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

            houses.Houses = _repo.GetHouses();
            houses.Cities = _repo.GetCities();
            houses.HouseSearch = new HouseSearch();
            /*var count = houses.Houses.Count();
            houses.Houses.Skip(page * PageSize).Take(PageSize).ToList();
            this.ViewBag.MaxPage =  (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            this.ViewBag.Page = page;*/

            return View(houses);
        }

        public IActionResult HouseDetails(int id)
        {

            House housedetail = _repo.HouseById(id);

            return View(housedetail);
        }

        public IActionResult GetHouses(int page = 1)
        {
            List<House> houses;
            houses = _repo.GetMyHouses();
            int pageSize = 1;
            int pageNumber = 1;

            return View(houses.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult UserDetails(string id)
        {
            ApplicationUser userdetails = _repo.UserById(id);

            return View(userdetails);

        }

        /*public async Task<IActionResult> Myhouses(int page = 1)
        {
            var _repo = new _repo();
            var houses = _repo.GetHouses().OrderBy(h => h.Id);
            //var model = await PagingList.CreateAsync(houses, 2, page);

           // return View(model);
        }*/
    }
}
