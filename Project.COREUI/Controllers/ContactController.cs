using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COREUI.ViemClasses;
using Project.ENTITIES.Entities;

namespace Project.COREUI.Controllers
{
    public class ContactController : Controller
    {
      private readonly  IContactManager _cMan;

        public ContactController(IContactManager cMan)
        {
            _cMan = cMan;
        }

        public IActionResult Index()
        {
            ContactVM cvm = new()
            {
                Contacts = _cMan.GetActives()
            };
            return View(cvm);
        }

        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _cMan.Add(contact);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContact(int id)
        {
            _cMan.Delete(_cMan.Find(id));
            return RedirectToAction("Index");
        }
        public IActionResult UpdateContact(int id)
        {
            ContactVM cvm = new()
            {
                Contact = _cMan.Find(id)
            };
            return View(cvm);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            _cMan.Update(contact);
            return RedirectToAction("Index");
        }

        public IActionResult DetailContact(int id)
        {
            ContactVM cvm = new()
            {
                Contact = _cMan.Find(id)
            };
            return View(cvm);
        }
        [HttpPost]
        public IActionResult DetailContact(Contact contact)
        {
            _cMan.Update(contact);
            return RedirectToAction("Index");
        }
    }
}
