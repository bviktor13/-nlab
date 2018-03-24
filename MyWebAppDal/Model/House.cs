using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace MyWebAppDal.Model
{
    public enum ForSaleType
    {
        [Display(Name = "Eladó")]
        Elado = 1,
        [Display(Name = "Kiadó")]
        Kiado = 2
    }

    public enum HouseType
    {
        [Display(Name = "Lakás")]
        Lakas = 1,
        [Display(Name = "Ház")]
        Haz = 2,
        [Display(Name = "Telek")]
        Telek = 3,
        [Display(Name = "Garázs")]
        Garazs = 4,
        [Display(Name = "Nyaraló")]
        Nyaralo = 5,
        [Display(Name = "Iroda")]
        Iroda = 6,
        [Display(Name = "Üzlethelyiség")]
        Uzlethelyiseg = 7,
        [Display(Name = "Raktár")]
        Raktar = 8,
        [Display(Name = "Ipari")]
        Ipari = 9,
        [Display(Name = "Egyéb")]
        Egyeb = 10
    }

    public enum HeatingType
    {
        [Display(Name = "Mindegy")]
        Mindegy = 0,
        [Display(Name = "Gáz cirko")]
        Gaz_cirko = 1,
        [Display(Name = "Gáz konvektor")]
        Gaz_konvektor = 2,
        [Display(Name = "Ház központi")]
        Hazkozponti = 3,
        [Display(Name = "Elektromos")]
        Elektromos = 4,
        [Display(Name = "Cserépkályha")]
        Cserepkalyha = 5,
        [Display(Name = "Távfűtés")]
        Tavfutes = 6,
        [Display(Name = "Egyéb")]
        Egyeb = 7
    }

    public enum InnerHeightType
    {
        [Display(Name = "Mindegy")]
        Mindegy = 0,
        [Display(Name = "3m-nél alacsaonyabb")]
        Harom_meternel_alacsonyabb = 1,
        [Display(Name = "3m-nél magasabb")]
        Harom_meternel_magasabb = 2,
    }

    public class House
    {


        public string ApplicationUserId { get; set; }  //Guid
        public int Id { get; set; }
        public ForSaleType? ForSaleType { get; set; }
        public int? Price { get; set; }
        public City City { get; set; }
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
