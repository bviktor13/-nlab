using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebAppDal.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
