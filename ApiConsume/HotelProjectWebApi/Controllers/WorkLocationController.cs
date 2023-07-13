using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var values = _workLocationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddWorkLocation([FromBody] WorkLocation workLocation)
        {
            _workLocationService.TInsert(workLocation);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TUpdate(workLocation);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkLocation([FromRoute] int id)
        {
            var value = _workLocationService.TGetById(id);
            _workLocationService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetWorkLocation([FromRoute] int id)
        {
            var value = _workLocationService.TGetById(id);
            return Ok(value);
        }
    }
}
