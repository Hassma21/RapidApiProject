using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomDal)
        {
            _roomService = roomDal;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetAll();
            return Ok(values);
        }
        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var values = _roomService.TRoomCount();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom([FromBody] Room room)
        {
            _roomService.TInsert(room);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomService.TUpdate(room);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom([FromRoute] int id)
        {
            var value= _roomService.TGetById(id);
            _roomService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom([FromRoute]int id)
        {
            var value= _roomService.TGetById(id);    
            return Ok(value);
        }
    }
}
