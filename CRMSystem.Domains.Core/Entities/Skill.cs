using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Skill:BaseEntity
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DueDay { get; set; }
        
        public List<Assessment> Assessments { get; set; }
        public int SupervisorID { get; set; }

        public User Supervisor { get; set; }

        public Competency Competency { get; set; }



    }

    public class Assessment
    {
        public int ID { get; set; }
        public int SAS { get; set; }
        public int SKAS { get; set; }
        public int IAS { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
