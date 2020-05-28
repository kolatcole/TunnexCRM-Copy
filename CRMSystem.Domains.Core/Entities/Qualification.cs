using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains.Core.Entities
{
    public class Qualification
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EmployeeID { get; set; }
    }
}
