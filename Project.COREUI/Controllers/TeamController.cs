using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COMMON.FluentValidations;
using Project.COREUI.ViemClasses;
using Project.ENTITIES.Entities;

namespace Project.COREUI.Controllers
{
    public class TeamController : Controller
    {
       private readonly ITeamManager _tMan;

        public TeamController(ITeamManager tMan)
        {
            _tMan = tMan;
        }

        public IActionResult Index()
        {
            TeamVM tvm = new TeamVM
            {
                Teams = _tMan.GetActives()
            };
            return View(tvm);
        }


        public IActionResult AddTeam()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);
            if (result.IsValid)
            {
                _tMan.Add(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName , item.ErrorMessage);
                }
            }
            return View();
           
        }

        public IActionResult DeleteTeam(int id)
        {
            _tMan.Delete(_tMan.Find(id));
            return RedirectToAction("Index");
        }


        public IActionResult UpdateTeam(int id)
        {
            TeamVM tvm = new TeamVM
            {
                Team = _tMan.Find(id)
            };
            return View(tvm);
        }
        [HttpPost]
        public IActionResult UpdateTeam(Team team)
        {
            _tMan.Update(team);
            return RedirectToAction("Index");
        }
    }
}
