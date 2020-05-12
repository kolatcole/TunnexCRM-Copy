using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public int UserCreated { get; set; }
        public int UserModified { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
