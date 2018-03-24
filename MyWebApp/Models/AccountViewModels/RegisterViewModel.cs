using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Felhasználó név")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó megerősítés")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Teljes Nev")]
        public string FullName { get; set; }

        [Display(Name = "Születési dátum")]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefonszám")]
        public string PhoneNumber { get; set; }
    }
}
