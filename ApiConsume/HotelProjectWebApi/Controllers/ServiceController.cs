using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddService([FromBody] Service Service)
        {
            _serviceService.TInsert(Service);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateService(Service Service)
        {
            _serviceService.TUpdate(Service);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService([FromRoute] int id)
        {
            var Service = _serviceService.TGetById(id);
            _serviceService.TDelete(Service);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetService([FromRoute] int id)
        {
            var value = _serviceService.TGetById(id);
            return Ok(value);
        }
    }
}
