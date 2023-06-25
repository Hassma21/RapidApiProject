using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutDal;

        public AboutController(IAboutService aboutDal)
        {
            _aboutDal = aboutDal;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutDal.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAbout([FromBody] About about)
        {
            _aboutDal.TInsert(about);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            _aboutDal.TUpdate(about);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout([FromRoute] int id)
        {
            var value = _aboutDal.TGetById(id);
            _aboutDal.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout([FromRoute] int id)
        {
            var value = _aboutDal.TGetById(id);
            return Ok(value);
        }
    }
}
