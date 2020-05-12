using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public interface IInvoiceRepo
    {

        Task<int> getLastAsync();

        Task<Invoice> getByNumberAsync(string invNumber);

        Task<List<Invoice>> getByCustomerIDAsync(int customerID);
    }
}
