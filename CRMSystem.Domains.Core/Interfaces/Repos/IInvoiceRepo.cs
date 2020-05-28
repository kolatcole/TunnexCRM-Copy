using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public interface IInvoiceRepo
    {

        Task<int> getLastAsync();

        Task<Invoice> getByNumberAsync(string invNumber,int customerID);

        Task<List<Invoice>> getByCustomerIDAsync(int customerID);

        Task<List<Invoice>> getAllDebtorsAsync();
    }
}
