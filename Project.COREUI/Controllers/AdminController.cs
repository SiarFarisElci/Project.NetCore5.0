using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.COREUI.Models;
using Project.ENTITIES.Entities;
using System.Threading.Tasks;

namespace Project.COREUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditVM userVm = new UserEditVM();
            userVm.Mail = values.Email;
            userVm.Phone = values.PhoneNumber;
            

            return View(userVm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditVM p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Password == p.ConfirmPassword)
            {
                values.Email = p.Mail;
                values.PhoneNumber = p.Phone;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
                var result = await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }

    }
}
