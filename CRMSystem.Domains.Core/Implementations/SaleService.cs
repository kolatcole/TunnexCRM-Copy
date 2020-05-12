using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains 
{ 
    public class SaleService:ISaleService
    {
        private readonly IRepo<Sale> _repo;
        private readonly ICartService _cService;
        private readonly IInvoiceService _inService;
        private readonly IRepo<Payment> _pRepo;
        public SaleService(IRepo<Sale> repo,  IInvoiceService inService, ICartService cService, IRepo<Payment> pRepo)
        {
            _repo = repo;
            _cService = cService;
            _inService = inService;
            _pRepo=pRepo;
        }
        public async Task<int> Save(Sale data)
        {

            


            // save cart

            var CID = await _cService.SaveCart(data.Cart);

            



            // get last Invoice ID to generate invoice number

            var LIID = await _inService.getLastAsync();
            string invNo = "";

            if (LIID == 0)
            {
                data.Invoice.InvoiceNo = "0000001";
                invNo = data.Invoice.InvoiceNo;
            }
            else 
            {
                LIID += 1;
                data.Invoice.InvoiceNo = LIID.ToString();
                data.Invoice.InvoiceNo.PadLeft(7, '0');
                invNo = data.Invoice.InvoiceNo;

            }

            // save payment if payment is available
            decimal totalAmt = 0;

            if (data.Payment != null)
            {
                foreach (var payment in data.Payment)
                {
                    payment.CustomerID = data.CustomerID;
                    payment.DatePaid = DateTime.Now;
                    payment.InvoiceNo = data.Invoice.InvoiceNo;
                    var PID = await _pRepo.insertAsync(payment);
                    totalAmt += payment.Amount;
                }

            }



            // still need to fix amount
            var invoice = new Invoice
            { 
                CustomerID=data.CustomerID,
                DateCreated=data.DateCreated,
                InvoiceDate=data.DateCreated,
                InvoiceNo= invNo,
                CartID = CID,
                Amount=data.Cart.Amount,
                AmountPaid=totalAmt,
                Balance=data.Cart.Amount-totalAmt

            };

            // save invoice


            var IID = await _inService.SaveInvoice(invoice);

            // save sale

            data.CartID = CID;
            // data.CartID = CID;
            data.InvoiceID = IID;
            var SID = await _repo.insertAsync(data);






            


            return SID;
        }
        public async Task<Sale> GetSaleByIDAsync(int ID)
        {
            var result = await _repo.getAsync(ID);
            return result;
        }
        public async Task<List<Sale>> GetAllSalesAsync()
        {
            var result = await _repo.getAllAsync();
            return result;
        }
    }
}
