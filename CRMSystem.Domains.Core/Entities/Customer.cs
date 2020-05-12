using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Customer:BaseEntity
    {
        
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
    }
}
