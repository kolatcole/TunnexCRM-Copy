using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Skill:BaseEntity
    {
       // public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


    }


    public class StaffSkill
    {
        public int ID { get; set; }
        public int StaffID { get; set; }
        public int SkillID { get; set; }

        public List<Assessment> Assessments { get; set; }
        public int SupervisorID { get; set; }

        [JsonIgnore]
        public decimal CompetencyValue { get { return 0.00M; } set { } }
    }
    public class Assessment
    {
        public int ID { get; set; }
        public int StaffSkillID { get; set; }
        public int SAS { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
