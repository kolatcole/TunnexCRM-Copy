using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{ 
    public class InvoiceService: IInvoiceService
    {
        private readonly IRepo<Invoice> _inRepo;
        private readonly IRepo<Cart> _cRepo;
        private readonly IInvoiceRepo _iRepo;
        public InvoiceService(IRepo<Invoice> inRepo,IRepo<Cart> cRepo, IInvoiceRepo iRepo)
        {
            _inRepo = inRepo;
            _cRepo = cRepo;
            _iRepo = iRepo;
        }

        public async Task<int> SaveInvoice(Invoice data)
        {
            // PENDING  var CID = await _cRepo.insertAsync(data.Cart);

            // PENDING data.CartID = CID;
            var IID = await _inRepo.insertAsync(data);
            return IID;
        }

        public async Task<Invoice> GetInvoiceByNumber(string InvNumber, int customerID)
        {

            var invoice = await _iRepo.getByNumberAsync(InvNumber,customerID);
            return invoice;

        }
        public async Task<List<Invoice>> GetInvoiceByCustomerID(int customerID)
        {

            var invoices = await _iRepo.getByCustomerIDAsync(customerID);
            return invoices;

        }
        public async Task<int> getLastAsync()
        {
            var lastNumber = await _iRepo.getLastAsync();
            return lastNumber;
        }

        public async Task<int> updateAsync(Invoice data)
        {
            var result = await _inRepo.updateAsync(data);
            return result;
        }
        public async Task<List<Invoice>> getDebtorInvoice(DateTime startdate,DateTime enddate)
        {
            var result = await _iRepo.getAllDebtorsAsync(startdate,enddate);
            return result;
        }
    }
}
