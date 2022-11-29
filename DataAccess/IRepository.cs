using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public interface IRepository
    {
       List<Member> GetAllMembers();
       void AddNewMember(Member member);
       void InsertNewMember(Member newmember);
       Member Update(Member member);
        void AddTickets(Ticket ticket);
        void UpdateTickets(Ticket ticket);
        Ticket GetTicketbyPaymentId(string paymentId);
    }
}
