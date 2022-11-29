using DataAccess;
using SAM.BaseRepo;
using SAM.Models;
using SAM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAM.Controllers
{
    [Authorize()]
    public class FoyerController : Controller
    {
        private IRepositoryBase _repository;

        public FoyerController(IRepositoryBase repository)
        {
            _repository = repository;
        }
        //
        // GET: /Foyer/

       // [Authorize(Roles="Administrator")]
        public ActionResult Index()
        {
            return View();
        }

       
        public JsonResult MemberList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
               
              
                var members = _repository.GetMemberlist();
                int count = members.Count();
                var sortedmemberlist = Datasource.GetMembers(members, jtStartIndex, jtPageSize, jtSorting);
                return Json(new { Result = "OK", Records = members, TotalRecordCount = count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult CreateMember(MemberModel member)
        {
            member.MemberId = CreateMemeberId(member.FirstName, member.LastName, member.PhoneNumber);
           // MemberModel model = CreateModel(member);
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                var addedMember = _repository.CreateMember(member);
                return Json(new { Result = "OK", Record = addedMember });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public string CreateMemeberId(string fname, string lname, string phone)
        {
            
            //Random rand= new Random();
            string memberid = fname.Substring(0, 1) + lname.Substring(0, 1) + phone.Substring(0, 3);
            return memberid;
        }

        [HttpPost]
        public JsonResult UpdateMember(MemberModel member)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                _repository.EditMember(member);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public MemberModel CreateModel(MemberVmodel member)
        {
            MemberModel model = new MemberModel();
            string[] addressarray = member.Address.Split(';');
            model.Address = addressarray[0];
            model.City = addressarray[1];
            model.ZipCode = addressarray[2];
            member.EmailAddress = member.EmailAddress;
            member.Phone = member.Phone;
            return model;
        }
        public ActionResult MemberRegistration()
        {
            return View();
        }

        public ActionResult Register(MemberModel model)
        {
             _repository.CreateMember(model);

            return RedirectToAction("Index", "Home");

        }
    }
}
