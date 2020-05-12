using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Privilege:BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool Read { get; set; }

        public bool Write { get; set; }
        public int RoleID { get; set; }

        
    }
}
