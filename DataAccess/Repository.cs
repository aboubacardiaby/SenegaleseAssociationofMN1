using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository : IRepository
    {
        SAMDBEntities _entity = new SAMDBEntities();
         public List<Member> GetAllMembers()
        {
            List<Member> list = new List<Member>();
            var query = _entity.Usp_GetAllMembers();
            foreach (var item in query)
            {
                list.Add(new Member() { Address = item.AddressLine1, City = item.City, Email = item.EmailAddress, FirstName = item.FirstName, LastName = item.LastName, MemberId = item.MemberId, PhoneNumber = item.PhoneNumber, State = item.State, ZipCode = item.ZipCode });
                
            }

            return list;
        }


         public void AddNewMember(Member newmember)
         {
             _entity.ADD_NEWMEMBER(newmember.FirstName, newmember.LastName, newmember.Address, "", newmember.City, newmember.State, newmember.ZipCode, newmember.PhoneNumber, newmember.Email, newmember.Createdby);
         }

         public void InsertNewMember(Member newmember)
         {

             _entity.ADD_NEWMEMBER(newmember.FirstName, newmember.LastName, newmember.Address, "", newmember.City, newmember.State, newmember.ZipCode, newmember.PhoneNumber, newmember.Email, newmember.Createdby);
         }
         public Member Update(Member member)
         {
             _entity.Usp_EditMember(member.MemberId, member.FirstName, member.LastName, "admin", member.PhoneNumber, member.Address, "", member.City, member.State, member.ZipCode, member.Email);
         var item=    _entity.Usp_GetAllMembers().Where(b => b.MemberId == member.MemberId).FirstOrDefault();
           return  new Member() { Address = item.AddressLine1, City = item.City, Email = item.EmailAddress, FirstName = item.FirstName, LastName = item.LastName, MemberId = item.MemberId, PhoneNumber = item.PhoneNumber, State = item.State, ZipCode = item.ZipCode };
         }

        public void AddTickets(Ticket ticket)
        {
            _entity.Tickets.Add(ticket);
            _entity.SaveChanges();
        }

        public void UpdateTickets(Ticket ticket)
        {
            var result = _entity.Tickets.SingleOrDefault(v => v.Id == ticket.Id);
            if (result != null)
            {
                result.PayPalReference = ticket.PayPalReference;
                _entity.SaveChanges();
            }
        }
       

        Ticket IRepository.GetTicketbyPaymentId(string paymentId)
        {
            var query = _entity.Tickets.Where(v => v.PayPalReference == paymentId).Select(v => v).FirstOrDefault();
            return query;
        }
    }
}
