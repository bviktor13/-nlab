using MyWebAppDal.DTO;
using System.Collections.Generic;

namespace MyWebApp.Models.AdvertisementViewModels
{
    public class EditHouseViewModel
    {
        public HouseDetailsDto EditedHouseDetails { get; set; }
        public IEnumerable<CityDto> Cities { get; set; }

        public int Id { get; set; }
    }
}
