using MyWebApp.Data;
using MyWebAppDal.DTO;
using MyWebAppDal.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAppDal.Repository
{
    public class Repository : IRepository
    {

        public IEnumerable<HouseDto> GetHouses()
        {

            using (var context = new ApplicationDbContext())
            {
                var houses = context.Houses.Select(h => new HouseDto
                {
                    ApplicationUserId = h.ApplicationUserId,
                    Id = h.Id,
                    Price = h.Price,
                    CityId = h.CityId,
                    Street = h.Street,
                    HouseNumber = h.HouseNumber,
                    Area = h.Area,
                    RoomNumber = h.RoomNumber,
                    PartyRoomNumber = h.PartyRoomNumber,
                    Image = h.Image,
                    ForSaleType =h.ForSaleType
                }).ToList();
                return houses;
            }
        }

        public UserSellerDto UserById(string Id)
        {

            using (var context = new ApplicationDbContext())
            {

                UserSellerDto userDto = context.Users.Select(user => new UserSellerDto
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Image = user.Image,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                }).SingleOrDefault(user => user.Id == Id);

                return userDto;
            }
        }


        public IEnumerable<CityDto> GetCities()
        {
            using (var context = new ApplicationDbContext())
            {
                var cities = context.Cities.Select(city => new CityDto
                {
                    Id = city.Id,
                    Name = city.Name
                }).ToList();

                return cities;
            }
        }

        public CityDto CityById(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                var cityDto = context.Cities.Select(city => new CityDto
                {
                    Id = city.Id,
                    Name = city.Name
                }).SingleOrDefault(city => city.Id == Id);

                return cityDto;

            }
        }
        public HouseDetailsDto HouseById(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                var house = context.Houses.Find(Id);

                HouseDetailsDto houseDetailsDto = new HouseDetailsDto
                {
                    Id = house.Id,
                    ApplicationUserId = house.ApplicationUserId,
                    ForSaleType = house.ForSaleType,
                    Price = house.Price,
                    CityId = house.CityId,
                    Street = house.Street,
                    HouseNumber = house.HouseNumber,
                    Area = house.Area,
                    RoomNumber = house.RoomNumber,
                    PartyRoomNumber = house.PartyRoomNumber,
                    HouseType = house.HouseType,
                    HeatingType = house.HeatingType,
                    Furnished = house.Furnished,
                    Animal = house.Animal,
                    Balcony = house.Balcony,
                    Elevator = house.Elevator,
                    Smoking = house.Smoking,
                    InnerHeightType = house.InnerHeightType,
                    Details = house.Details,
                    Image = house.Image,
                };

               return houseDetailsDto;
            }
        }

        public void DeleteHouse(int id)
        {
            var context = new ApplicationDbContext();

            var deleteHouse = context.Houses.Find(id);
            var favourites = context.Favourites.Where(f => f.HouseId == deleteHouse.Id).ToList();

            foreach (var item in favourites)
            {
                    context.Favourites.Remove(item);
                    context.SaveChanges();             
            }

            context.Houses.Remove(deleteHouse);
            context.SaveChanges();

        }


        public void AddToDataBase(HouseDetailsDto houseDetails)
        {
            House house = new House
            {
                Id = houseDetails.Id,
                ApplicationUserId = houseDetails.ApplicationUserId,
                ForSaleType = houseDetails.ForSaleType,
                Price = houseDetails.Price,
                CityId = houseDetails.CityId,
                Street = houseDetails.Street,
                HouseNumber = houseDetails.HouseNumber,
                Area = houseDetails.Area,
                RoomNumber = houseDetails.RoomNumber,
                PartyRoomNumber = houseDetails.PartyRoomNumber,
                HouseType = houseDetails.HouseType,
                HeatingType = houseDetails.HeatingType,
                Furnished = houseDetails.Furnished,
                Animal = houseDetails.Animal,
                Balcony = houseDetails.Balcony,
                Elevator = houseDetails.Elevator,
                Smoking = houseDetails.Smoking,
                InnerHeightType = houseDetails.InnerHeightType,
                Details = houseDetails.Details,
                Image = houseDetails.Image,
            };

            var context = new ApplicationDbContext();

            context.Houses.Add(house);
            context.SaveChanges();
        }

        public void UpdateLastHouse(HouseDetailsDto houseDetails)
        {
            var context = new ApplicationDbContext();

            var updateHouse = context.Houses.Last();
            updateHouse.ForSaleType = houseDetails.ForSaleType;
            updateHouse.Price = houseDetails.Price;
            updateHouse.CityId = houseDetails.CityId;
            updateHouse.Street = houseDetails.Street;
            updateHouse.HouseNumber = houseDetails.HouseNumber;
            updateHouse.Area = houseDetails.Area;
            updateHouse.RoomNumber = houseDetails.RoomNumber;
            updateHouse.PartyRoomNumber = houseDetails.PartyRoomNumber;
            updateHouse.HouseType = houseDetails.HouseType;
            updateHouse.HeatingType = houseDetails.HeatingType;
            updateHouse.Furnished = houseDetails.Furnished;
            updateHouse.Animal = houseDetails.Animal;
            updateHouse.Balcony = houseDetails.Balcony;
            updateHouse.Elevator = houseDetails.Elevator;
            updateHouse.Smoking = houseDetails.Smoking;
            updateHouse.InnerHeightType = houseDetails.InnerHeightType;
            updateHouse.Details = houseDetails.Details;
            updateHouse.Image = houseDetails.Image;
            context.Update(updateHouse);
            context.SaveChanges();
        }

        public void SaveProfilePicture(string userId, string profilePictureName)
        {
            var context = new ApplicationDbContext();
            var user = context.Users.Single(appuser => appuser.Id == userId);
            user.Image = profilePictureName;
            context.Update(user);
            context.SaveChanges();
        }
        public string GetCityName(int Id)
        {
            using (var context = new ApplicationDbContext())
            {

                string cityName = context.Cities.Find(Id).Name;

                return cityName;
            }

        }

        public void AddToFavourites(FavouriteDto favourite)
        {

            Favourite newFavourite = new Favourite
            {
                Id = favourite.Id,
                ApplicationUserId = favourite.ApplicationUserId,
                HouseId = favourite.HouseId
            };

            var context = new ApplicationDbContext();

            var alreadyContains = context.Favourites.FirstOrDefault(f => f.ApplicationUserId == favourite.ApplicationUserId && f.HouseId == favourite.HouseId);

            if (alreadyContains == null)
            {

                context.Favourites.Add(newFavourite);
                context.SaveChanges();
            }

        }

        public IEnumerable<FavouriteDto> GetUserFavourites(string loggedInUserId)
        {
            using (var context = new ApplicationDbContext())
            {


                var favourites = context.Favourites.Select(f => new FavouriteDto
                {
                    ApplicationUserId = f.ApplicationUserId,
                    HouseId = f.HouseId
                }).Where(f => f.ApplicationUserId == loggedInUserId).ToList();

                return favourites;
            }

        }

        public List<HouseDto> GetUserFavouriteHouses(string loggedInUserId)
        {
            var userFavourites = GetUserFavourites(loggedInUserId);

            var userFavouriteHouses = new List<HouseDto>() ;

            

            foreach (var favourite in userFavourites)
            {
                var house = GetHouses().SingleOrDefault(h => h.Id == favourite.HouseId);
                userFavouriteHouses.Add(house);
            }

             
            return userFavouriteHouses;

        }

        public void DeleteUserFavourite(int Id)
        {
            var context = new ApplicationDbContext();

            var deleteUserFavourite = context.Favourites.Find(Id);

            context.Favourites.Remove(deleteUserFavourite);
            context.SaveChanges();
        }

        public int FindFavouriteId(string userId , int houseId)
        {
            using (var context = new ApplicationDbContext())
            {

                int favouriteid = context.Favourites.FirstOrDefault(f => f.ApplicationUserId == userId && f.HouseId == houseId).Id;


                return favouriteid;
            }

        }

        public void UpdateMyHouse(int Id , HouseDetailsDto houseDetails)
        {
            var context = new ApplicationDbContext();

            var updateHouse = context.Houses.Find(Id);
            updateHouse.ForSaleType = houseDetails.ForSaleType;
            updateHouse.Price = houseDetails.Price;
            updateHouse.CityId = houseDetails.CityId;
            updateHouse.Street = houseDetails.Street;
            updateHouse.HouseNumber = houseDetails.HouseNumber;
            updateHouse.Area = houseDetails.Area;
            updateHouse.RoomNumber = houseDetails.RoomNumber;
            updateHouse.PartyRoomNumber = houseDetails.PartyRoomNumber;
            updateHouse.HouseType = houseDetails.HouseType;
            updateHouse.HeatingType = houseDetails.HeatingType;
            updateHouse.Furnished = houseDetails.Furnished;
            updateHouse.Animal = houseDetails.Animal;
            updateHouse.Balcony = houseDetails.Balcony;
            updateHouse.Elevator = houseDetails.Elevator;
            updateHouse.Smoking = houseDetails.Smoking;
            updateHouse.InnerHeightType = houseDetails.InnerHeightType;
            updateHouse.Details = houseDetails.Details;
            updateHouse.Image = houseDetails.Image;
            context.Update(updateHouse);
            context.SaveChanges();
        }

        public IEnumerable<HouseDto> SearchedHouses(HouseSearchDto search)
        {

            using (var context = new ApplicationDbContext())
            {
                var houses = context.Houses.ToList();

                    if(search.ForSaleType != null)
                    {
                    houses = houses.Where(h => h.ForSaleType == search.ForSaleType).ToList();
                    }
                    if (search.HouseType != null)
                    {
                        houses = houses.Where(h => h.HouseType == search.HouseType).ToList();
                    }
                    if (search.CityId != null)
                    {
                        houses = houses.Where(h => h.CityId == search.CityId).ToList();
                    }
                    if (search.MinPrice != null)
                    {
                        houses = houses.Where(h => h.Price > search.MinPrice).ToList();
                    }
                    if (search.MaxPrice != null)
                    {
                        houses = houses.Where(h => h.Price < search.MaxPrice).ToList();
                    }

                    if (search.MinArea != null)
                    {
                        houses = houses.Where(h => h.Area > search.MinArea).ToList();
                    }
                    if (search.MaxArea != null)
                    {
                        houses = houses.Where(h => h.Area < search.MaxArea).ToList();
                    }
                    if (search.RoomNumber != null)
                    {
                        houses = houses.Where(h => h.RoomNumber >= search.RoomNumber).ToList();
                    }
                    if (search.PartyRoomNumber != null)
                    {
                        houses = houses.Where(h => h.PartyRoomNumber >= search.PartyRoomNumber).ToList();
                    }

                    if (search.HeatingType != null)
                    {
                        houses = houses.Where(h => h.HeatingType == search.HeatingType).ToList();
                    }

                    if (search.InnerHeightType != null)
                    {
                        houses = houses.Where(h => h.InnerHeightType == search.InnerHeightType).ToList();
                    }
                    if (search.Furnished != false)
                    {
                        houses = houses.Where(h => h.Furnished == search.Furnished).ToList();
                    }


                    if (search.Animal != false)
                    {
                        houses = houses.Where(h => h.Animal == search.Animal).ToList();
                    }
                    if (search.Balcony != false)
                    {
                        houses = houses.Where(h => h.Balcony == search.Balcony).ToList();
                    }


                    if (search.Elevator != false)
                    {
                        houses = houses.Where(h => h.Elevator == search.Elevator).ToList();
                    }
                    if (search.Smoking != false)
                    {
                        houses = houses.Where(h => h.Smoking == search.Smoking).ToList();
                    }

                    var houseSearch = houses.Select(h => new HouseDto
                    {
                        ApplicationUserId = h.ApplicationUserId,
                        Id = h.Id,
                        Price = h.Price,
                        CityId = h.CityId,
                        Street = h.Street,
                        HouseNumber = h.HouseNumber,
                        Area = h.Area,
                        RoomNumber = h.RoomNumber,
                        PartyRoomNumber = h.PartyRoomNumber,
                        Image = h.Image,
                        ForSaleType = h.ForSaleType
                    }).ToList();

                    return houseSearch;

                
            }

        }

        public void AddToSearches(HouseSearchDto search)
        {

            HouseSearch houseSearch = new HouseSearch
            {
                ForSaleType = search.ForSaleType,
                MinPrice = search.MinPrice,
                MaxPrice = search.MaxPrice,
                CityId = search.CityId,
                MinArea = search.MinArea,
                MaxArea = search.MaxArea,
                RoomNumber = search.RoomNumber,
                PartyRoomNumber = search.PartyRoomNumber,
                HouseType = search.HouseType,
                HeatingType = search.HeatingType,
                Furnished = search.Furnished,
                Animal = search.Animal,
                Balcony = search.Balcony,
                Elevator = search.Elevator,
                Smoking = search.Smoking,
                InnerHeightType = search.InnerHeightType,
            };

            var context = new ApplicationDbContext();

            context.HouseSearches.Add(houseSearch);
            context.SaveChanges();


        }
        public ApplicationDbContext Context()
        {

            var context = new ApplicationDbContext();
            
               
                return context;
            
        }
    }
}

