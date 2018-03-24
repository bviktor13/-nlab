using MyWebAppDal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebAppDal.DTO
{
    public class HouseDto
    {
        public int Id { get; set; }
        public int? Price { get; set; }
        public int? CityId { get; set; }
        public string Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? Area { get; set; }
        public int? RoomNumber { get; set; }
        public int? PartyRoomNumber { get; set; }
        public string Image { get; set; }
    }
}
