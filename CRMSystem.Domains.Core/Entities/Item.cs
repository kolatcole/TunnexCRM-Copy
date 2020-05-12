using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Item
    {
        public int ID { get; set; }
        public int CartID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

     //   public Product Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal Amount { get; set; }

        public int ProductID { get; set; }
    }
}
