using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }
        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values= _sendMessageService.TGetAll();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult AddSendMessage([FromBody] SendMessage sendMessage)
        {
            _sendMessageService.TInsert(sendMessage);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TUpdate(sendMessage);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage([FromRoute] int id)
        {
            var value = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage([FromRoute] int id)
        {
            var value = _sendMessageService.TGetById(id);
            return Ok(value);
        }
    }
}
