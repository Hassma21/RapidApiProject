using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.WorkLocationDto
{
    public class CreateWorkLocationDto
    {
        [Required(ErrorMessage = "Lokasyon Adı Giriniz")]
        public string? WorkLocationName { get; set; }
        [Required(ErrorMessage = "Lokasyon Şehri Giriniz")]
        public string? WorkLocationCity { get; set; }
      
    }
}
