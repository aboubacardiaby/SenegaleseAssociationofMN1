using Mvc.Mailer;
using System.Net.Mail;

namespace SAM.Mailers
{ 
    public interface IUserMailer
    {
        MvcMailMessage Welcome(string body, string Subject, string email);
			MvcMailMessage GoodBye();
            MailMessage Welcome1(string body, string Subject, string email);
	}
}