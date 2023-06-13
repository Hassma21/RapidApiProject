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
        private readonly IRoomDal _roomDal;

        public RoomController(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomDal.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom([FromBody] Room room)
        {
            _roomDal.Insert(room);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomDal.Update(room);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteRoom([FromRoute] int id)
        {
            var value=_roomDal.GetById(id);
            _roomDal.Delete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom([FromRoute]int id)
        {
            var value= _roomDal.GetById(id);    
            return Ok(value);
        }
    }
}
