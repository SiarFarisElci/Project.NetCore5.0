using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COREUI.ViemClasses;
using Project.ENTITIES.Entities;

namespace Project.COREUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IAdressManager _aMan;
        private readonly IAboutManager _abMan;
        private readonly IServiceManager _sMan;
        private readonly ITeamManager _tMan;
        private readonly INewManager _nMan;
        private readonly IImageManager _iMan;
        private readonly IContactManager _cMan;


        public DefaultController(IAdressManager aMan, IAboutManager abMan, IServiceManager sMan, ITeamManager tMan, INewManager nMan, IImageManager iMan, IContactManager cMan)
        {
            _aMan = aMan;
            _abMan = abMan;
            _sMan = sMan;
            _tMan = tMan;
            _nMan = nMan;
            _iMan = iMan;
            _cMan = cMan;
        }

        public IActionResult Index()
        {
         
            DefaultVM dvm = new()
            {
                Adresses = _aMan.GetActives(),
                Abouts = _abMan.GetActives(),
                Services = _sMan.GetActives(),
                Teams = _tMan.GetActives(),
                News = _nMan.GetActives(),
                Images = _iMan.GetActives()
            };
            return View(dvm);
        }

      
        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {
            _cMan.Add(contact);
            return RedirectToAction("Index");
        }
    }
}
