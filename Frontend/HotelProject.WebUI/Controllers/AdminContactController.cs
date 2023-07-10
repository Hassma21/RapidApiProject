using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AdminContactController> _logger;
        public AdminContactController(IHttpClientFactory httpClientFactory, ILogger<AdminContactController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public PartialViewResult SideBarAdminContactPartial()
        {
       
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> Inbox()
        {
            
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5227/api/Contact");

            var response2 = await client.GetAsync("http://localhost:5227/api/Contact/GetContactCount");
            var response3 = await client.GetAsync("http://localhost:5227/api/SendMessage/GetSendMessageCount");
            if (response.IsSuccessStatusCode) {
            
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

                var jsonData2 = await response2.Content.ReadAsStringAsync();
                var jsonData3 = await response3.Content.ReadAsStringAsync();

                ViewBag.InboxCount = jsonData2;
                ViewBag.SendboxCount = jsonData3;
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5227/api/SendMessage");

            
            var response2 = await client.GetAsync("http://localhost:5227/api/Contact/GetContactCount");
            var response3 = await client.GetAsync("http://localhost:5227/api/SendMessage/GetSendMessageCount");
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);

                var jsonData2 = await response2.Content.ReadAsStringAsync();
                var jsonData3 = await response3.Content.ReadAsStringAsync();

                ViewBag.InboxCount = jsonData2;
                ViewBag.SendboxCount = jsonData3;

                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> InMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5227/api/Contact/{id}");
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> SendMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5227/api/SendMessage/{id}");
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSendMessageDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderMail = "admin@gmail.com";
            model.SenderName = "admin";
            model.Date = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5227/api/SendMessage", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }
    }
}
