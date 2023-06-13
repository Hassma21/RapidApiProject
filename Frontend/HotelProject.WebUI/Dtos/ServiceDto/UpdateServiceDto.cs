using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Hizmet İkonu Giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet Başlığı Giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı En fazla 100 Karakter Olabilir.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet Açıklaması Giriniz")]
        [StringLength(500, ErrorMessage = "Hizmet Açıklaması En fazla 500 Karakter Olabilir.")]
        public string Description { get; set; }
    }
}
