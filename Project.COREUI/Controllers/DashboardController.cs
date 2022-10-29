using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COREUI.ViemClasses;

namespace Project.COREUI.Controllers
{
    public class DashboardController : Controller
    {
        IContactManager _cMan;
        ITeamManager _tMan;
        IServiceManager _sMan;
        INewManager _nMan;
    

        public DashboardController(ITeamManager tMan, IServiceManager sMan , IContactManager cMan, INewManager nMan)
        {
            _cMan = cMan;
            _tMan = tMan;
            _sMan = sMan;
            _nMan = nMan;
        }
        public IActionResult Index()
        {
            TempData["toplamTeam"]  = _tMan.GetActives().Count;
            TempData["toplamService"]  = _sMan.GetActives().Count;
            TempData["toplamMessage"]  = _cMan.GetActives().Count;
            TempData["toplamDuyuru"]  = _nMan.GetActives().Count;

            DashboardVM dvm = new DashboardVM()
            {
                Contacts = _cMan.GetActives()
            };

            return View(dvm);
        }
    }
}
