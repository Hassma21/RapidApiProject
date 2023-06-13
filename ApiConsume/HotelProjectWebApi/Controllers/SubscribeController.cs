using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSubscribe([FromBody] Subscribe Subscribe)
        {
            _subscribeService.TInsert(Subscribe);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe Subscribe)
        {
            _subscribeService.TUpdate(Subscribe);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe([FromRoute] int id)
        {
            var Subscribe = _subscribeService.TGetById(id);
            _subscribeService.TDelete(Subscribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe([FromRoute] int id)
        {
            var value = _subscribeService.TGetById(id);
            return Ok(value);
        }

    }
}
