using System;
using System.Collections.Generic;

namespace DAL
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Boolean Status { get; set; }
        public enum StatusEnum { Active, Inactive }
        public StatusEnum Status1 { get; set; }
    }
}
