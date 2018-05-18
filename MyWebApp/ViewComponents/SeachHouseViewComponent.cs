using Microsoft.AspNetCore.Mvc;
using MyWebAppDal.DTO;
using MyWebAppDal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.ViewComponents
{
    public class SearchHouseViewComponent : ViewComponent
    {

        private IRepository _repo;

        public SearchHouseViewComponent(IRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IViewComponentResult> InvokeAsync(HouseSearchDto search)
        {
            
            ViewData["Cities"] = _repo.GetCities();

            return View(search);
        }

    }
}
