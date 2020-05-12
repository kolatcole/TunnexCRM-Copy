using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public List<Privilege> Privileges { get; set; }

       
    }
}
