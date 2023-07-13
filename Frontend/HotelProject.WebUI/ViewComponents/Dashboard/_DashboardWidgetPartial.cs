using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseBookingMessage = await client.GetAsync("http://localhost:5227/api/Booking/BookingCount");
            if (responseBookingMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseBookingMessage.Content.ReadAsStringAsync();//Coming data is just one that's wht we dont need Dto or viewmodel
                ViewBag.BookingCount = jsonData.ToString(); 
            }
            
            var responseStaffMessage = await client.GetAsync("http://localhost:5227/api/Staff/StaffCount");
            if (responseStaffMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseStaffMessage.Content.ReadAsStringAsync();//Coming data is just one that's wht we dont need Dto or viewmodel
                ViewBag.StaffCount = jsonData.ToString();
            }
            var responseUserMessage = await client.GetAsync("http://localhost:5227/api/AppUser/UserCount");
            if (responseUserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseUserMessage.Content.ReadAsStringAsync();//Coming data is just one that's wht we dont need Dto or viewmodel
                ViewBag.UserCount = jsonData.ToString();
            }
            var responseRoomMessage = await client.GetAsync("http://localhost:5227/api/Room/RoomCount");
            if (responseRoomMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseRoomMessage.Content.ReadAsStringAsync();//Coming data is just one that's wht we dont need Dto or viewmodel
                ViewBag.RoomCount = jsonData.ToString();
            }
            return View();
        }
    }
}
