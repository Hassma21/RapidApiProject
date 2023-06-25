using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        List<ApiMovieViewModel>? apiMovieViewModels = new List<ApiMovieViewModel>();
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies1.p.rapidapi.com/"),
                Headers =
    {
<<<<<<< HEAD
        { "X-RapidAPI-Key", "*****************" },
        { "X-RapidAPI-Host", "*****************" },
=======
        { "X-RapidAPI-Key", "79724c73d1msh8ab2b62151d505fp17b518jsn32d05d17adaa" },
        { "X-RapidAPI-Host", "imdb-top-100-movies1.p.rapidapi.com" },
>>>>>>> d7f78b64cfff90a0d1fa5ee8910fdb0a8cd9fc29
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovieViewModels = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apiMovieViewModels);
            }

        }
    }
}
