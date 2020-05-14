using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepo<Payment> _pRepo;
        private readonly IInvoiceService _iService;
        public PaymentService(IRepo<Payment> pRepo, IInvoiceService iService)
        {
            _pRepo = pRepo;
            _iService = iService;
        }
        public async Task<int> PayAsync(Payment data)
        {
            // get invoice to make payment on
            var invoice = await _iService.GetInvoiceByNumber(data.InvoiceNo, data.CustomerID);

            var payment = new Payment
            {
                DatePaid = DateTime.Now,
                CustomerID=data.CustomerID,
                Amount=data.Amount,
                InvoiceNo=data.InvoiceNo,
                Method=data.Method,
                Reference=data.Reference,
                UserCreated=data.UserCreated
                
            };

            //save payment

            var PID = await _pRepo.insertAsync(payment);

            // update invoice with latest payment record

            invoice.AmountPaid += data.Amount;
            invoice.Balance = invoice.Amount - invoice.AmountPaid;
            if (invoice.Balance == 0)
                invoice.IsPaid = true;

            await _iService.updateAsync(invoice);

            return PID;


        }
    }
}
