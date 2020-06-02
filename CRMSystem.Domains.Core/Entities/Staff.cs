using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Staff:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string HEL { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public DateTime DateofBirth { get; set; }
        
        public List<Qualification> Qualifications { get; set; }


    }
}
