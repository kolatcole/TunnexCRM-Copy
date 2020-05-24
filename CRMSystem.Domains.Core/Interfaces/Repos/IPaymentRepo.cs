using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public interface IPaymentRepo
    {
        Task<List<Payment>> getPaymentByInvoiceNo(string invNo); 
    }
}
