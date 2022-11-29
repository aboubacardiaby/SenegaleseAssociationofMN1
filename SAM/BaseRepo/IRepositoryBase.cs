using DataAccess;
using SAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.BaseRepo
{
   public interface IRepositoryBase
    {
        List<MemberModel> GetMemberlist();
       MemberModel CreateMember(MemberModel member);

       MemberModel EditMember(MemberModel member);
       void AddTickets(TicketModel ticket);
       void UpdateTicket(Ticket ticket);
        TicketModel GetTicketbyPaymentId(string paymentId);


    }
}
