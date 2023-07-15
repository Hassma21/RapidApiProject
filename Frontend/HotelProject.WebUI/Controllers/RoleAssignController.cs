using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HotelProject.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values =_userManager.Users.ToList();
            return View(values);
        }
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            if(user != null)
            {
                TempData["userid"] = user.Id;
                var roles =_roleManager.Roles.ToList();
                var userRoles = await _userManager.GetRolesAsync(user);
                List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
                foreach (var role in roles)
                {
                    RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel()
                    {
                        RoleId = role.Id,
                        RoleName = role.Name,
                        RoleExist =userRoles.Contains(role.Name)
                    };
                    roleAssignViewModels.Add(roleAssignViewModel);

                }
                return View(roleAssignViewModels);

            }
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach(var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");

        }
    }
}
