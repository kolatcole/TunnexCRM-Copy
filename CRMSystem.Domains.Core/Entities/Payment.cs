using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Payment
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
        public string Reference { get; set; }

        public DateTime DatePaid { get; set; }

        public string InvoiceNo { get; set; }

        public int UserCreated { get; set; }

      //  public Customer Customer { get; set; }
    }
}
