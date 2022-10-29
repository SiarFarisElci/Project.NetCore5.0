using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project.BLL.ManagerServices.Abstracts;
using Project.COREUI.ViemClasses;
using Project.ENTITIES.Entities;

namespace Project.COREUI.Controllers
{
    public class NewController : Controller
    {
       private readonly INewManager _nMan;

        public NewController(INewManager nMan)
        {
            _nMan = nMan;
        }

        public IActionResult Index()
        {
            NewVM nvm = new NewVM
            {
                News = _nMan.GetActives()
            };
            return View(nvm);
        }

        public IActionResult AddNew()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddNew(New @new )
        {
            _nMan.Add(@new);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNew(int id)
        {
            _nMan.Delete(_nMan.Find(id));
            return RedirectToAction("Index");
        }

        public IActionResult UpdateNew(int id)
        {
            NewVM nvm = new NewVM
            {
                New = _nMan.Find(id)
            };
            return View(nvm);
        }
        [HttpPost]
        public IActionResult UpdateNew(New @new)
        {
            _nMan.Update(@new);
            return RedirectToAction("Index");
        }
    }
}
