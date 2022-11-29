using SAM.BaseRepo;
using SAM.Mailers;
using SAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using Mvc.Mailer;
using System.Net;
using System.Net.Mail;

namespace SAM.Controllers
{
    public class HomeController : Controller
    {
        public IRepositoryBase _repository;

        public HomeController(IRepositoryBase repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {


            return View();
        }

        public ActionResult whoweare()
        {


            return View();
        }

        public ActionResult Contact()
        {
            //IUserMailer mailer = new UserMailer();
            //mailer.Welcome().Send();

            return View();
        }

        public ActionResult Calendar()
        {


            return View();
        }

        public ActionResult AboutSenegal()
        {


            return View();
        }
        public ActionResult _Ticker()
        {


            return PartialView("_Ticker");
        }
        public ActionResult Historique()
        {


            return View();
        }
        public ActionResult MotduPresident()
        {


            return View();
        }
        public ActionResult executivecommittee()
        {


            return View();
        }
        public ActionResult Gallery()
        {


            return View();
        }
        public ActionResult ProgramDetails()
        {


            return View();
        }


        public ActionResult Links()
        {


            return View();
        }
        public ActionResult MemberAssistances()
        {


            return View();
        }
        public ActionResult ToDonate()
        {

            return View();
        }

        public string Sendemail(MailMessageModel model)
        {
            string fromaddr = model.EmailAddress;
            string toaddr = "samsupport@senegalesemn.com";
            string password = "Latdiordiop24";


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.Subject = "Username &password";
            msg.From = new MailAddress(fromaddr);
            msg.Body = "Message BODY";
            msg.To.Add(new MailAddress("samsupport@senegalesemn.com"));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.secureserver.net";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            //smtp.EnableSsl = true;
           NetworkCredential nc = new NetworkCredential(fromaddr, password);
           smtp.Credentials = nc;
            smtp.Send(msg);
            return null;
        }

        
    }
}
