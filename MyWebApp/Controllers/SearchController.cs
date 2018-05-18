using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models.SearchViewModels;
using MyWebAppDal.DTO;
using MyWebAppDal.Repository;
using ReflectionIT.Mvc.Paging;

namespace MyWebApp.Controllers
{
    public class SearchController : Controller
    {

        private IRepository _repo;
        private readonly IHostingEnvironment _environment;

        public SearchController(IRepository repo,IHostingEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, string sort = "Price")
        {

            var query = _repo.GetHouses();

            var model = new SearchHousesViewModels
            {
                Houses = PagingList.Create(query, 2, pageNumber,sort,"Price"),
                Search = new HouseSearchDto()
            };
     
            ViewData["Cities"] = _repo.GetCities();

            model.Houses.PageParameterName = "pageNumber";
            model.Houses.SortExpressionParameterName = "Price";

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Index( HouseSearchDto search)
        {

            var query = _repo.SearchedHouses(search);

            var model = new SearchHousesViewModels
            {
                Houses = PagingList.Create(query, 2, 1),
                Search = search
            };


            ViewData["Cities"] = _repo.GetCities();

            model.Houses.PageParameterName = "pageNumber";
            model.Houses.SortExpressionParameterName = "Price";


            return View(model);

        }

        public IActionResult AddSearchToDb(HouseSearchDto search)
        {
            _repo.AddToSearches(search);

            return RedirectToAction("Index", "Search");

        }


        public IActionResult AddToFavourites(int id)
        {
           string loggedInUserId = HttpContext.User.Claims.FirstOrDefault().Value;

            FavouriteDto addFavourite = new FavouriteDto
            {
                HouseId = id,
                ApplicationUserId = loggedInUserId
            };

            _repo.AddToFavourites(addFavourite);

             return RedirectToAction("Index", "Search");
        }

        public IActionResult Result(int id)
        {
            var house = _repo.HouseById(id);
            var seller = _repo.UserById(house.ApplicationUserId);
            var resultHouse = new ResultHouseViewModel
            {
                houseDetails = house,
                userSeller = seller
            };

            string path = Path.Combine(_environment.WebRootPath, "HouseUploads");
            string getPath = Path.Combine(path, id.ToString());
	        string[] filePaths = Directory.GetFiles(getPath);
            string[] fileName = Directory.GetFiles(getPath); 



            for (int i = 0; i < filePaths.Count(); i++)
            {
                fileName[i] = Path.GetFileName(filePaths[i]);
            }


            ViewData["Cities"] = _repo.GetCities();
            ViewData["Images"] = fileName;

            return View(resultHouse);
        }
    }
}