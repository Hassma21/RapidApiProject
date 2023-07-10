using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public IActionResult GetContacts()
        {
           var values=_contactService.TGetAll();
            return Ok(values);
        }
        [HttpGet("GetContactCount")]
        public IActionResult GetContactsCount()
        {
            var values = _contactService.TGetContactCount();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddContact([FromBody] Contact contact)
        {
            contact.Date=Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact([FromRoute] int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetContact([FromRoute] int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
    }
}
