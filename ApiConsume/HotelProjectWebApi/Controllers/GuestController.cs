using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService bookingService)
        {
            _guestService = bookingService;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _guestService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddGuest([FromBody] Guest guest)
        {
            _guestService.TInsert(guest);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return Ok();
        }
       
        [HttpDelete("{id}")]
        public IActionResult DeleteGuest([FromRoute] int id)
        {
            var staff = _guestService.TGetById(id);
            _guestService.TDelete(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest([FromRoute] int id)
        {
            var value = _guestService.TGetById(id);
            return Ok(value);
        }
    }
}
