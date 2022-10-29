using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COMMON.FluentValidations;
using Project.COREUI.ViemClasses;
using Project.ENTITIES.Entities;
using System.Collections.Generic;

namespace Project.COREUI.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageManager _iman;

        public ImageController(IImageManager iman)
        {
            _iman = iman;
        }

        public IActionResult Index()
        {
            ImageVM ivm = new ImageVM
            {
                Images = _iman.GetActives()
            };
            return View(ivm);
        }


        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image image)
        {
            ImageValidator validationRules = new();
            ValidationResult result = validationRules.Validate(image);

            if (result.IsValid)
            {
                _iman.Add(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (ValidationFailure item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName , item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteImage(int id)
        {
            _iman.Delete(_iman.Find(id));
            return RedirectToAction("Index");
        }

        public IActionResult UpdateImage(int id
            )
        {
            ImageVM ivm = new ImageVM
            {
                Image = _iman.Find(id)
            };
            return View(ivm);
        }
        [HttpPost]
        public IActionResult UpdateImage(Image image)
        {
            _iman.Update(image);
            return RedirectToAction("Index");
        }
    }
}
