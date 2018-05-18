using MyWebApp.Data;
using MyWebAppDal.DTO;
using System.Collections.Generic;

namespace MyWebAppDal.Repository
{
    public interface IRepository
    {
        IEnumerable<HouseDto> GetHouses();
        UserSellerDto UserById(string Id);

        IEnumerable<CityDto> GetCities();

        HouseDetailsDto HouseById(int Id);

        ApplicationDbContext Context();

        void DeleteHouse(int id);

        void AddToDataBase(HouseDetailsDto houseDetails);
        void SaveProfilePicture(string userId, string profilePictureName);
        string GetCityName(int Id);
        CityDto CityById(int Id);
        void AddToFavourites(FavouriteDto favourite);
        IEnumerable<FavouriteDto> GetUserFavourites(string loggedInUserId);
        List<HouseDto> GetUserFavouriteHouses(string loggedInUserId);
        void DeleteUserFavourite(int Id);
        int FindFavouriteId(string userId, int houseId);
        void UpdateLastHouse(HouseDetailsDto houseDetails);
        void UpdateMyHouse(int Id , HouseDetailsDto houseDetails);
        IEnumerable<HouseDto> SearchedHouses(HouseSearchDto search);
        void AddToSearches(HouseSearchDto search);


    }
}
