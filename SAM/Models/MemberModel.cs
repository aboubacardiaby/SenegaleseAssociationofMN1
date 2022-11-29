using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAM.Models
{
    public class MemberModel
    {
        public string MemberId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "An address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "A City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        //[Required(ErrorMessage = "An Album Title is required")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        public string Position { get; set; }

        public bool IsActive { get; set; }
    }
}