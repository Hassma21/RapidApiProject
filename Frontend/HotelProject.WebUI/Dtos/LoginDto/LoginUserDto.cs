using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı alanı gerekli")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı gerekli")]
        public string Password { get; set; }
    }
}
