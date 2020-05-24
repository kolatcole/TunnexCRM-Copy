using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Lead:BaseEntity
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public List<Message> Message { get; set; }
    }

    public class Message:BaseEntity
    { 
        public string Type { get; set; }
        public string Summary { get; set; }
        public int LeadID { get; set; }
    }
}
