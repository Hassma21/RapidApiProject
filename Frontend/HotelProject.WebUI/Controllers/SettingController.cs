using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel()
            {
                Name = user.UserName,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email,
            };
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(UserEditViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index","Login");
           
        }
    }
}
