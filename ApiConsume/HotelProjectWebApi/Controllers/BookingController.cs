using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetAll();
            return Ok(values);
        }
        [HttpGet("Last3")]
        public IActionResult BookingLast3()
        {
            var values = _bookingService.TGetLast3Booking();
            return Ok(values);
        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var values = _bookingService.TBookingCount();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking([FromBody] Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpPut("UpdateReservationBooking")]
        public IActionResult UpdateReservationBooking(Booking booking)
        {
            _bookingService.TBookingStatusChangeApproved(booking);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking([FromRoute] int id)
        {
            var staff = _bookingService.TGetById(id);
            _bookingService.TDelete(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking([FromRoute] int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
