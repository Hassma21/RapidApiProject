using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.SubscribeDto
{
    public class CreateSubscribeDto
    {
        [Required(ErrorMessage ="Lütfen Mailinizi giriniz")]
        public string Mail { get; set; }
    }
}
