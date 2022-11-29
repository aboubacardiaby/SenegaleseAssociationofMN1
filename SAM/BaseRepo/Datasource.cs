using SAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAM.BaseRepo
{
    public class Datasource
    {

        public static List<MemberModel> GetMembers(IEnumerable<MemberModel> query, int startIndex, int count, string sorting)
        {
          

            
            if (string.IsNullOrEmpty(sorting) || sorting.Equals("Name ASC"))
            {
                query = query.OrderBy(p => p.LastName);
            }
            else if (sorting.Equals("Name DESC"))
            {
                query = query.OrderByDescending(p => p.LastName);
            }
           
            else if (sorting.Equals("CityId ASC"))
            {
                query = query.OrderBy(p => p.City);
            }
            else if (sorting.Equals("CityId DESC"))
            {
                query = query.OrderByDescending(p => p.City);
            }
          
            else if (sorting.Equals("IsActive ASC"))
            {
                query = query.OrderBy(p => p.IsActive);
            }
            else if (sorting.Equals("IsActive DESC"))
            {
                query = query.OrderByDescending(p => p.IsActive);
            }
            else
            {
                query = query.OrderBy(p => p.LastName); //Default!
            }

            return count > 0
                       ? query.Skip(startIndex).Take(count).ToList() //Paging
                       : query.ToList(); //No paging
        }
    }
}