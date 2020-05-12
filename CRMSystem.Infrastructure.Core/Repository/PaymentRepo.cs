using CRMSystem.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Infrastructure
{
    public class PaymentRepo : IRepo<Payment>
    {
        private readonly TContext _context;
        public PaymentRepo(TContext context)
        {
            _context = context;
        }
        public Task<int> deleteAsync(Payment data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Payment>> getAllAsync()
        {

            try
            {
                var payment = await _context.Payments.ToListAsync();
                return payment;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<Payment> getAsync(int ID)
        {
            try
            {
                var payment = await _context.Payments.Where(x => x.ID == ID).FirstOrDefaultAsync();
                return payment;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> insertAsync(Payment data)
        {
            var payment = new Payment();
            try
            {
                if (data != null)
                {

                    payment = new Payment
                    {
                       
                        UserCreated = data.UserCreated,
                        Amount=data.Amount,
                        DatePaid= DateTime.Now,
                        InvoiceNo=data.InvoiceNo,
                        Method=data.Method,
                        Reference=data.Reference,
                        CustomerID=data.CustomerID
                    };
                    await _context.Payments.AddAsync(payment);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return payment.ID;
        }

        public Task<int> insertListAsync(List<Payment> data)
        {
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(Payment data)
        {
            throw new NotImplementedException();
            //int ID = 0;
            //var payment = await _context.Payments.FindAsync(data.ID);
            //try
            //{
            //    if (payment != null)
            //    {
            //        payment. = DateTime.Now;
            //        newProduct.UserModified = data.UserModified;
            //        newProduct.Quantity = data.Quantity;
            //        newProduct.Name = data.Name;
            //        newProduct.Image = data.Image;

            //        _context.Products.Update(newProduct);
            //        ID = await _context.SaveChangesAsync();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return ID;
        }
    }
}
