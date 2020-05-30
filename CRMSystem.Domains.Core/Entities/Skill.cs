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
        public int SAS { get; set; }
        public int SKAS { get; set; }
        public int IAS { get; set; }

    }
}
