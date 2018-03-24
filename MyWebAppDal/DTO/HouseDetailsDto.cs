using MyWebAppDal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebAppDal.DTO
{
    class HouseDetailsDto
    {
        public int Id { get; set; }
        public ForSaleType? ForSaleType { get; set; }
        public int? Price { get; set; }
        public int? CityId { get; set; }
        public string Street { get; set; } //Class?
        public int? HouseNumber { get; set; }
        public int? Area { get; set; }
        public int? RoomNumber { get; set; }
        public int? PartyRoomNumber { get; set; }
        public HouseType? HouseType { get; set; }
        public HeatingType? HeatingType { get; set; }
        public bool Furnished { get; set; }
        public bool Animal { get; set; }
        public bool Balcony { get; set; }
        public bool Elevator { get; set; }
        public bool Smoking { get; set; }
        public InnerHeightType? InnerHeightType { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
    }
}
