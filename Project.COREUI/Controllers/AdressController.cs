using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COMMON.FluentValidations;
using Project.COREUI.ViemClasses;
using Project.ENTITIES.Entities;

namespace Project.COREUI.Controllers
{
    public class AdressController : Controller
    {
       private readonly IAdressManager _aMan;
        public AdressController(IAdressManager aMan)
        {
            _aMan = aMan;
        }

        public IActionResult Index()
        {
            AdressVM avm = new()
            {
                Adresses = _aMan.GetActives()
            };
            return View(avm);
        }

        public IActionResult AddAdress()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddAdress(Adress adress)
        {
            AdressValidator validationRules = new AdressValidator();
            ValidationResult result = validationRules.Validate(adress);
            if (result.IsValid)
            {
                _aMan.Add(adress);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }

        public IActionResult DeleteAdress(int id)
        {
            _aMan.Delete(_aMan.Find(id));
            return RedirectToAction("Index");
        }

        public IActionResult UpdateAdress(int id)
        {
            AdressVM avm = new()
            {
                Adress = _aMan.Find(id)
            };
            return View(avm);
        }
        [HttpPost]
        public IActionResult UpdateAdress(Adress adress)
        {
            _aMan.Update(adress);
            return RedirectToAction("Index");
        }

    }
}
