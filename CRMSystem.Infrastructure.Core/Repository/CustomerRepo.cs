using CRMSystem.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CRMSystem.Infrastructure
{
    public class CustomerRepo : IRepo<Customer>
    {
        private readonly TContext _context;
        public CustomerRepo(TContext context)
        {
            _context = context;
        }
        public Task<int> deleteAsync(Customer data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> getAllAsync()
        {
            var customer = await _context.Customers.ToListAsync();
            return customer;

        }

        //public async Task<List<Customer>> getAllByIDAsync(int ID)
        //{
        //    var customer = await _context.Customers.Where(x=>x.UserCreated==ID).ToListAsync();
        //    return customer;
        //}

        public async Task<Customer> getAsync(int ID)
        {
            var customer = await _context.Customers.Where(x => x.ID == ID).FirstOrDefaultAsync();
            return customer;

        }

        public async Task<int> insertAsync(Customer data)
        {
            var customer = new Customer();
            try
            {
                if (data != null)
                {
                    customer = new Customer
                    {
                        DateCreated = DateTime.Now,
                        UserCreated = data.UserModified,
                        FirstName=data.FirstName,
                        Address=data.Address,
                        Email=data.Email,
                        Gender=data.Gender,
                        Image=data.Image,
                        LastName=data.LastName,
                        Phone=data.Phone
                    };
                    await _context.Customers.AddAsync(customer);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer.ID;
        }

        public Task<int> insertListAsync(List<Customer> data)
        {
            throw new NotImplementedException();
        }

        public async Task<int> updateAsync(Customer data)
        {
            int ID = 0;
            var newCustomer = await _context.Customers.FindAsync(data.ID);
            try
            {
                if (newCustomer != null)
                {
                    newCustomer.Image = data.Image;
                    newCustomer.FirstName = data.FirstName;
                    newCustomer.Phone = data.Phone;
                    newCustomer.LastName = data.LastName;
                    newCustomer.DateModified = DateTime.Now;
                    newCustomer.UserModified = data.UserModified;
                    newCustomer.Gender = data.Gender;
                    newCustomer.Email = data.Email;
                    newCustomer.Address = data.Address;
                    

                    _context.Customers.Update(newCustomer);
                    ID = await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newCustomer.ID;
        }
    }
}
