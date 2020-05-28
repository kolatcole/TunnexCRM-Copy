using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public interface IInvoiceService
    {
        Task<int> SaveInvoice(Invoice data);
        Task<Invoice> GetInvoiceByNumber(string InvNumber, int customerID);
        Task<List<Invoice>> GetInvoiceByCustomerID(int customerID);
        Task<int> getLastAsync();

        Task<int> updateAsync(Invoice data);
        Task<List<Invoice>> getDebtorInvoice();
    }
}
