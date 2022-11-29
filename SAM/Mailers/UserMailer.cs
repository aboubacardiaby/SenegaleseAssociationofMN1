using Mvc.Mailer;
using System.Net.Mail;
//using System.Web.Mail;
//using System.Net.Mail;

namespace SAM.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Welcome(string body, string Subject, string email)
		{
            ViewBag.Data = "someObject";
            return Populate(x =>
            {
                x.Subject = Subject;
                x.ViewName = body;
                x.To.Add(email);
                x.Body = body;

            });

            //var message = new MailMessage();

            //message.To.Add("user@example.com");
            //message.To.Add("user2@example.com");

            //message.From = new MailAddress("test@example.com");
            //message.Subject = "Test";
            //message.Body = "Test";

            //return Populate(message, "Welcome");
           ;
		}
        public virtual MailMessage Welcome1(string body, string Subject, string email)
        {
            var mailMessage = new MailMessage { Subject = "Welcome" };

            mailMessage.To.Add("hajan@hajan.com");
            ViewBag.Name = "Hajan";
            PopulateBody(mailMessage, viewName: "Welcome");
            return mailMessage;
        }
		public virtual MvcMailMessage GoodBye()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "GoodBye";
				x.ViewName = "GoodBye";
				x.To.Add("some-email@example.com");
			});
		}
 	}
}