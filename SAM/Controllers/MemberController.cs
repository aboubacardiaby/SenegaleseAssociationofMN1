using DataAccess;
using SAM.BaseRepo;
using SAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAM.Controllers
{
    public class MemberController : Controller
    {
        private IRepositoryBase _repository;
        //
        // GET: /Member/
        public MemberController(IRepositoryBase repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MemberRegistration()
        {
            return View();
        }

        public ActionResult VolunteerRegistration()
        {
            return View();
        }
        public ActionResult Register(MemberModel model)
        {
            _repository.CreateMember(model);

            return RedirectToAction("Index", "Home");

        }
        public ActionResult Registervolunteer(MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
            }
            _repository.CreateMember(model);

            return RedirectToAction("Index", "Home");

        }
    }
}
