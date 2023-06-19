using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad alanı gerekli")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gerekli")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı alanı gerekli")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail alanı gerekli")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre alanı gerekli")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı gerekli")]
        [Compare("Password",ErrorMessage ="Şifre aynı olmalı")]
        public string ConfirmPassword { get; set; }
    }
}
