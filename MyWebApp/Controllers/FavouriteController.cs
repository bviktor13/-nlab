using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models.FavouriteViewModels;
using MyWebAppDal.Repository;
using System.Linq;

namespace MyWebApp.Controllers
{
    public class FavouriteController : Controller
    {
        private IRepository _repo;
        private readonly IHostingEnvironment _environment;

        public FavouriteController(IRepository repo, IHostingEnvironment enviroment)
        {
            _repo = repo;
            _environment = enviroment;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "A kedvenceid.";

            var loggedInUserId = HttpContext.User.Claims.FirstOrDefault().Value;

            var cities = _repo.GetCities().ToList();
            var favouriteHouses = _repo.GetUserFavouriteHouses(loggedInUserId);

            var userFavourites = new ShowFavourites
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

            return RedirectToAction(nameof(Index));
        }
    }
}