using System;
using System.Collections.Generic;
using System.Text;


namespace MyWebAppDal.Models
{
    public class HouseSearch
    {
        public int Id { get; set; }
        public ForSaleType? ForSaleType { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
        public string Street { get; set; }
        public int? MinArea { get; set; }
        public int? MaxArea { get; set; }
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
    }
}
