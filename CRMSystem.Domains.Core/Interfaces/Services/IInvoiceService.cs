using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public interface IInvoiceService
    {
        Task<int> SaveInvoice(Invoice data);
        Task<Invoice> GetInvoiceByNumber(string InvNumber);
        Task<List<Invoice>> GetInvoiceByCustomerID(int customerID);
        Task<int> getLastAsync();
    }
}
