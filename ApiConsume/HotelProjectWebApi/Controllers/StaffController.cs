using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var values=_staffService.TGetAll();
            return Ok(values);
        }
        [HttpGet("Last4")]
        public IActionResult StaffLast4()
        {
            var values = _staffService.TGetLast4Staff();
            return Ok(values);
        }
        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var values = _staffService.TGetStaffCount();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddStaff([FromBody]Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff([FromRoute]int id)
        {
            var staff=_staffService.TGetById(id);
            _staffService.TDelete(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff([FromRoute] int id)
        {
            var value =_staffService.TGetById(id);
            return Ok(value);
        }
    }
}
