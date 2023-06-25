using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5227/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        
        public async Task<IActionResult> ApprovedResarvation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var getResponse = await client.GetAsync($"http://localhost:5227/api/Booking/{id}");
            if (getResponse.IsSuccessStatusCode)
            {
                var jsonData = await getResponse.Content.ReadAsStringAsync();
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "applicaiton/json");
                var responseMessage = await client.PutAsync($"http://localhost:5227/api/Booking/UpdateReservationBooking", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            
            return View();

        }
    }
}
