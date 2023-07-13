using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.WorkLocationDto
{
    public class UpdateWorkLocationDto
    {
        public int WorkLocationId { get; set; }
        [Required(ErrorMessage = "Lokasyon Adı Giriniz")]
        public string? WorkLocationName { get; set; }
        [Required(ErrorMessage = "Lokasyon Şehri Giriniz")]
        public string? WorkLocationCity { get; set; }
    }
}
