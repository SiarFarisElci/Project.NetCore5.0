
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COREUI.Models;
using Project.ENTITIES.Entities;
using System.Threading.Tasks;

namespace Project.COREUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly IAppUserManager _aMan;
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager , IAppUserManager aMan)
		{
			_aMan = aMan;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public async Task< IActionResult> Index(SingUpVM singUpVM)
        {
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(singUpVM.username , singUpVM.password , false , true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index" , "Dashboard");
				}
				else
				{
					return RedirectToAction("Index");
				}
			}

            return View();
        }

        public IActionResult SingUp()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> SingUp(RegisterViewModel  registerViewModel)
        {
			AppUser appUser = new AppUser()
			{
				UserName = registerViewModel.userName,
				Email = registerViewModel.mail
			};
				
				
			

			if (registerViewModel.password == registerViewModel.passwordConfirm)
			{
				var result = await _userManager.CreateAsync(appUser , registerViewModel.password);

				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("" , item.Description);
					}
				}



			}
			
            return View(registerViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
