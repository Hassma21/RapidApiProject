using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult GetAppUsers()
        {
            var values = _appUserService.TGetAll();
            return Ok(values);
        }
        [HttpGet("UserCount")]
        public IActionResult GetAppUserCount()
        {
            var values = _appUserService.TAppUserCount();
            return Ok(values);
        }
        [HttpGet("UserListWithLocation")]
        public IActionResult GetAppUsersWithLocation()
        {
            var values = _appUserService.TUserListWithLocation();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAppUser([FromBody] AppUser appUser)
        {
            _appUserService.TInsert(appUser);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAppUser([FromRoute] int id)
        {
            var value = _appUserService.TGetById(id);
            _appUserService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAppUser([FromRoute] int id)
        {
            var value = _appUserService.TGetById(id);
            return Ok(value);
        }
    }
}
