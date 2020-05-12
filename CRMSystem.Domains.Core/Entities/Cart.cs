using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRMSystem.Domains
{
    public class Cart:BaseEntity
    {
        public string Code { get; set; }

        public List<Item> Items { get; set; }
        [Column(TypeName ="decimal(18,4)")]
        public decimal Amount { get; set; }
        //public int InvoiceID { get; set; }
        //public int SaleID { get; set; }

    }
}
