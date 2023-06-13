using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Numarasını Giriniz")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Oda görseli Giriniz")]
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Fiyatını Giriniz")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Başlığını Giriniz")]
        [StringLength(100,ErrorMessage ="En fazla 100 karakter girişi yapabilirsiniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Yatak Sayısını Giriniz")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Banyo Sayısını Giriniz")]
        public string BathCount { get; set; }
        [Required(ErrorMessage = "Lütfen Wifi şifresi Giriniz")]
        public string Wifi { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Açıklamasını Giriniz")]
        public string Description { get; set; }
    }
}
