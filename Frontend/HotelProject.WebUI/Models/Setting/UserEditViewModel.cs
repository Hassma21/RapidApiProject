using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Setting
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Ad alanı gerekli")]
        public string ?Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı gerekli")]
        public string ?Surname { get; set; }
        [Required(ErrorMessage = "Mail alanı gerekli")]
        public string ?Email { get; set; }
        public string ?UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı gerekli")]
        public string ?Password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar alanı gerekli")]
        [Compare("Password", ErrorMessage = "Şifre aynı olmalı")]
        public string ?ConfirmPassword { get; set; }

    }
}
