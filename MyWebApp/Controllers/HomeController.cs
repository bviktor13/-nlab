using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Models.HomeViewModels;
using MyWebAppDal.DTO;
using MyWebAppDal.Repository;
using ReflectionIT.Mvc.Paging;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private readonly IHostingEnvironment _environment;

        public HomeController(IRepository repo , IHostingEnvironment enviroment)
        {
            _repo = repo;
            _environment = enviroment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Advertisement()
        {
            ViewData["Message"] = "Hirdetes feladása vagy törlése";

            var cities = _repo.GetCities().ToList();
            
            var loggedInUserId = HttpContext.User.Claims.FirstOrDefault().Value;

            var userHouses = _repo.GetHouses().Where(user => user.ApplicationUserId == loggedInUserId).ToList();

            var newHouse = new AddHouseViewModel
            {
                Cities = cities,
                House = new HouseDetailsDto(),
                UserHouses = userHouses
            };




            return View(newHouse);
        }

        [HttpPost]
        public async Task<IActionResult> Advertisement(HouseDetailsDto house, List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {

                var newHouse = new AddHouseViewModel
                {
                    House = house,
                    Cities = _repo.GetCities().ToList()
                };


                return View("Advertisement", newHouse);
            }


            house.ApplicationUserId = HttpContext.User.Claims.FirstOrDefault().Value;

            if (files != null)
            {
                _repo.AddToDataBase(house);

                int houseId = _repo.GetHouses().LastOrDefault().Id;

                foreach (var file in files)
                {
                    string uploadPath = Path.Combine(_environment.WebRootPath, "HouseUploads");
                    Directory.CreateDirectory(Path.Combine(uploadPath, houseId.ToString()));
                    string fileName = Path.GetFileName(file.FileName);

                    using (FileStream fs = new FileStream(Path.Combine(uploadPath, houseId.ToString(), fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fs);

                    }

                    house.Image = fileName;
                }
            }
           
            return RedirectToAction(nameof(Advertisement));
        }

        public IActionResult Favourite()
        {
            ViewData["Message"] = "A kedvenceid.";

            var loggedInUserId = HttpContext.User.Claims.FirstOrDefault().Value;

            var cities = _repo.GetCities().ToList();
            var favouriteHouses = _repo.GetUserFavouriteHouses(loggedInUserId);

            var userFavourites = new FavouritesViewModel
            {
                Cities = cities,
                FavouriteHouses = favouriteHouses,
            };
            
            return View(userFavourites);
        }

        public IActionResult DeleteMyFavourite(int Id)
        {
            var loggedInUserId = HttpContext.User.Claims.FirstOrDefault().Value;

            int favouriteId = _repo.FindFavouriteId(loggedInUserId, Id);

            _repo.DeleteUserFavourite(favouriteId);

            return RedirectToAction(nameof(Favourite));
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
            houses.HouseSearch = new HouseSearchDto();
            /*var count = houses.Houses.Count();
            houses.Houses.Skip(page * PageSize).Take(PageSize).ToList();
            this.ViewBag.MaxPage =  (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            this.ViewBag.Page = page;*/

            return View(houses);
        }

        public IActionResult HouseDetails(int id)
        {


            HouseDetailsView houseDetails = new HouseDetailsView();

            houseDetails.HouseDetails = _repo.HouseById(id);

            houseDetails.City = _repo.CityById(houseDetails.HouseDetails.CityId.Value);
            


            return View(houseDetails);
        }



        public IActionResult DeleteMyHouse(int id)
        {
            _repo.DeleteHouse(id);

             return RedirectToAction("Advertisement", "Home");
        }

    }
}
