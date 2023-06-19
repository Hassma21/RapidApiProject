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
        private readonly IRoomService _roomDal;

        public RoomController(IRoomService roomDal)
        {
            _roomDal = roomDal;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomDal.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom([FromBody] Room room)
        {
            _roomDal.TInsert(room);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomDal.TUpdate(room);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteRoom([FromRoute] int id)
        {
            var value=_roomDal.TGetById(id);
            _roomDal.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom([FromRoute]int id)
        {
            var value= _roomDal.TGetById(id);    
            return Ok(value);
        }
    }
}
