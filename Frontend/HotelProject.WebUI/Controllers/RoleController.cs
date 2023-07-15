using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
           AppRole appRole = new AppRole()
           {
               Name = model.Name,
           };
            var result =await _roleManager.CreateAsync(appRole);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role =  _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

            }
            
            return View();
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if (role != null)
            {
                UpdateRoleViewModel model = new UpdateRoleViewModel()
                {
                    RoleName = role.Name,
                    Id = role.Id
                };
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
            if (role != null)
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            
            return View();
        }
    }
}
