using DataAccess;
using SAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAM.BaseRepo
{
    public class RepositoryBase : IRepositoryBase
    {
        IRepository db = new Repository();
        public List<Models.MemberModel> GetMemberlist()
        {
            List<MemberModel> mlist = new List<MemberModel>();
            var memberlist = db.GetAllMembers();
            foreach (var item in memberlist)
            {
                mlist.Add(new MemberModel(){ Address = item.Address, City = item.City, Email = item.Email, FirstName = item.FirstName, LastName = item.LastName, MemberId = item.MemberId, PhoneNumber = item.PhoneNumber, State = item.State, ZipCode = item.ZipCode });
            }
            return mlist;
        }
        public MemberModel CreateMember(MemberModel member)
        {
            db.AddNewMember(new Member() { FirstName = member.FirstName, LastName = member.LastName, Address = member.Address, City = member.City, Createdby = "abou", Email = member.Email, PhoneNumber= member.PhoneNumber, ZipCode=member.ZipCode, State= member.State });

            return null;
        }


        public MemberModel EditMember(MemberModel member)
        {
          var query=  db.Update(new Member() { FirstName = member.FirstName, LastName = member.LastName, Address = member.Address, City = member.City, Createdby = "abou", Email = member.Email, PhoneNumber= member.PhoneNumber, ZipCode=member.ZipCode, State= member.State });
          var model = new MemberModel() { FirstName = query.FirstName, LastName = query.LastName, Address = query.Address, City = query.City, Email = query.Email, PhoneNumber = query.PhoneNumber, ZipCode = query.ZipCode, State = query.State };
          return model;
        }

        public void AddTickets(TicketModel ticket)
        {
            db.AddTickets(new Ticket()
            {
                DonationDate = ticket.DonationDate,
                Email = ticket.Email,
                FirstName = ticket.FirstName,
                LastName = ticket.LastName,
                PayPalReference = ticket.LastName
            });
        }
        public void UpdateTicket(Ticket ticket)
        {
            db.AddTickets(ticket);
        }

        public TicketModel GetTicketbyPaymentId(string paymentId)
        {
          var query =  db.GetTicketbyPaymentId(paymentId);

            TicketModel ticket = new TicketModel()
            {
                PayPalReference = query.PayPalReference,
                DonationDate = query.DonationDate,
                Email = query.Email,
                FirstName = query.FirstName,              
                LastName = query.LastName
            };
            return ticket;
        }
    }
}