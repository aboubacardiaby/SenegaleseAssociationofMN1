using DataAccess;
using PayPal.Api;
using SAM.BaseRepo;
using SAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAM.Controllers
{
    public class DonationController : Controller
    {
        private IRepositoryBase _repository;

        public DonationController(IRepositoryBase repository)
        {
            _repository = repository;
        }
        //
        // GET: /Donation/

        public ActionResult Index()
        {
            var model = GetDonationInfo();
            return View(model);
        }
        private string Logic(string amount)
        {
            var Amountwithout = amount;
            bool isDollarTrue = amount.Contains("$");
            bool is00True = amount.Contains(".00");
            if (isDollarTrue)
            {
                Amountwithout = Amountwithout.Trim('$');
            }
            if(!is00True)
            {
                Amountwithout = string.Format("{0}.00", Amountwithout);
            }
            return Amountwithout;
        }
        [HttpPost]
        public ActionResult Index(DonationModel model)
        {
            string amount = "";
            if (ModelState.IsValid)
            {
                // Fetch the tour info from the server and NOT from the POST data.
                // Otherwise users could manipulate the data
                var DonationInfo = GetDonationInfo();

                amount = Logic(model.Price.ToString()); 
                // Create a Ticket object to store info about the purchaser
                var ticket = new TicketModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    DonationDate = DonationInfo.DonationDate,


                };
                _repository.AddTickets(ticket);
              

                // Get PayPal API Context using configuration from web.config
                var apiContext = GetApiContext();

                // Create a new payment object
                var payment = new Payment
                {
                    experience_profile_id = "XP-GJ8U-JERJ-S4LQ-CWMW",
                    //"XP-QNTQ-FQQX-DYJR-BUWN", // Created in the WebExperienceProfilesController. This one is for DigitalGoods.
                    intent = "sale",
                    payer = new Payer
                    {
                        payment_method = "paypal"
                    },
                    transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            description = $"Senegalese Association donation (Single Payment) for {DonationInfo.DonationDate:dddd, dd MMMM yyyy}",
                            amount = new Amount
                            {
                                currency = "USD",
                                total = amount, // PayPal expects string amounts, eg. "20.00"
                            },
                            item_list = new ItemList()
                            {
                                items = new List<Item>()
                                {
                                    new Item()
                                    {
                                        description = $"Senegalese Association donation (Single Payment) for {DonationInfo.DonationDate:dddd, dd MMMM yyyy}",
                                        currency = "USD",
                                        quantity = "1",
                                        price = amount
                                        //(DonationInfo.Price).ToString(), // PayPal expects string amounts, eg. "20.00"                                        
                                    }
                                }
                            }
                        }
                    },
                    redirect_urls = new RedirectUrls
                    {
                        return_url = Url.Action("Return", "Donation", null, Request.Url.Scheme),
                        cancel_url = Url.Action("Cancel", "Donation", null, Request.Url.Scheme)
                    }
                };

                // Send the payment to PayPal
                var createdPayment = payment.Create(apiContext);

                // Save a reference to the paypal payment
                ticket.PayPalReference = createdPayment.id;
                _repository.AddTickets(ticket);

                // Find the Approval URL to send our user to
                var approvalUrl =
                    createdPayment.links.FirstOrDefault(
                        x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

                // Send the user to PayPal to approve the payment
                return Redirect(approvalUrl.href);
            }

            return View(model);
        }

        public ActionResult Return(string payerId, string paymentId)
        {
            // Fetch the existing ticket
            var ticket = _repository.GetTicketbyPaymentId(paymentId);

            // Get PayPal API Context using configuration from web.config
            var apiContext = GetApiContext();

            // Set the payer for the payment
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };

            // Identify the payment to execute
            var payment = new Payment()
            {
                id = paymentId
            };

            // Execute the Payment
            var executedPayment = payment.Execute(apiContext, paymentExecution);

            return RedirectToAction("Thankyou");
        }

        public ActionResult Cancel()
        {
            return View();
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        private APIContext GetApiContext()
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            return apiContext;
        }
        private DonationModel GetDonationInfo()
        {
            return new DonationModel()
            {
                // Always set tour for tomorrow
                DonationDate = DateTime.Today.AddDays(1),
                // Represent price in cents to avoid rounding errors
                // Price = 2000
            };
        }

    }
}
