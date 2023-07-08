using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestiominialController : ControllerBase
    {
        private readonly ITestiomanialService _testiominialService;

        public TestiominialController(ITestiomanialService testiominialService)
        {
            _testiominialService = testiominialService;
        }

        [HttpGet]
        public IActionResult TestiominialList()
        {
            var values = _testiominialService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddTestiominial([FromBody] Testimonial Testiominial)
        {
            _testiominialService.TInsert(Testiominial);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTestiominial(Testimonial Testiominial)
        {
            _testiominialService.TUpdate(Testiominial);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestiominial([FromRoute] int id)
        {
            var Testiominial = _testiominialService.TGetById(id);
            _testiominialService.TDelete(Testiominial);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetTestiominial([FromRoute] int id)
        {
            var value = _testiominialService.TGetById(id);
            return Ok(value);
        }
    }
}
