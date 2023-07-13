using HotelProject.WebUI.Dtos.SocialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribesCountPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardSubscribesCountPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var requestInstagram = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scraper-2022.p.rapidapi.com/ig/info_username/?user=muhammeddd_ylmaz"),
                Headers =
    {
        { "X-RapidAPI-Key", "*************************" },
        { "X-RapidAPI-Host", "instagram-scraper-2022.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(requestInstagram))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultInstagramDto>(body);
                ViewBag.InstagramFollowersCount = value?.user.follower_count;
            }



            var requestLinkedln = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://linkedin-profiles1.p.rapidapi.com/extract?url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fmuhammed-y%25C4%25B1lmaz-07b990229%2F&html=false"),
                Headers =
    {
        { "X-RapidAPI-Key", "*************************************" },
        { "X-RapidAPI-Host", "linkedin-profiles1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(requestLinkedln))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultLinkedlnDto>(body);
                ViewBag.LinkedlnFollowersCount = value?.extractor.interactionStatistic.userInteractionCount;
            }
            return View();
        }
    }
}
