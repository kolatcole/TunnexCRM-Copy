using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Qualification
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StaffID { get; set; }
    }
}
