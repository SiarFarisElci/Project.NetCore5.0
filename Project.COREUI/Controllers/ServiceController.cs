using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COREUI.ViemClasses;
using Project.ENTITIES.Entities;

namespace Project.COREUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceManager _sMan;

        public ServiceController(IServiceManager sMan)
        {
            _sMan = sMan;
        }

        public IActionResult Index()
        {
            ServiceVM svm = new ServiceVM()
            {
                Services = _sMan.GetActives()
            };
            return View(svm);
        }


        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _sMan.Add(service);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteService(int id)
        {
            _sMan.Delete(_sMan.Find(id));
            return RedirectToAction("Index");
        }


        public IActionResult UpdateService(int id)
        {
            ServiceVM svm = new ServiceVM
            {
                Service = _sMan.Find(id)
            };
            return View(svm);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _sMan.Update(service);
            return RedirectToAction("Index");
        }

        public IActionResult DenemeService( )
        {
           
            return View();
        }
    }
}
