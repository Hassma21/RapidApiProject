using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast4WorkerPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLast4WorkerPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseBookingMessage = await client.GetAsync("http://localhost:5227/api/Staff/Last4");
            if (responseBookingMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseBookingMessage.Content.ReadAsStringAsync();//Coming data is just one that's wht we dont need Dto or viewmodel
                var values = JsonConvert.DeserializeObject<List<ResultStaffLast4Dto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
