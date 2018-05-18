using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models.AdvertisementViewModels;
using MyWebAppDal.DTO;
using MyWebAppDal.Repository;

namespace MyWebApp.Controllers
{
    public class AdvertisementController : Controller
    {
        private IRepository _repo;
        private readonly IHostingEnvironment _environment;

        public AdvertisementController(IRepository repo, IHostingEnvironment enviroment)
        {
            _repo = repo;
            _environment = enviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
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
        public async Task<IActionResult> Index(HouseDetailsDto house, List<IFormFile> files)
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

                _repo.UpdateLastHouse(house);
            }
        
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteMyHouse(int id)
        {
            _repo.DeleteHouse(id);

            return RedirectToAction("Index", "Advertisement");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           
            var editHouse = _repo.HouseById(id);
            var cities = _repo.GetCities();

            var house = new EditHouseViewModel
            {
                EditedHouseDetails = editHouse,
                Cities = cities,
                Id = id,
            };

            return View(house);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditHouseViewModel editHouse, IFormFile file)
        {
            if (editHouse.Id != 0)
            {
                _repo.UpdateMyHouse(editHouse.Id, editHouse.EditedHouseDetails);
            }

            return RedirectToAction("Index", "Advertisement");
        }

      

    }
}