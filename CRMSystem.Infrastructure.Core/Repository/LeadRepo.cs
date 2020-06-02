using CRMSystem.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Infrastructure
{
    public class LeadRepo : IRepo<Lead>
    {
        private readonly TContext _context;
        public LeadRepo(TContext context)
        {
            _context = context;
        }

        
        public Task<int> deleteAsync(Lead data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Lead>> getAllAsync()
        {
            var leads = await _context.Leads.Where(x => x.isCustomer == false).Include(y => y.Message).ToListAsync();
            return leads;
        }

        public Task<List<Lead>> getAllByIDAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Lead> getAsync(int ID)
        {
            var lead = await _context.Leads.Include(y=>y.Message).Where(x => x.ID == ID && x.isCustomer==false).FirstOrDefaultAsync();
            return lead;
        }

        public Task<List<Lead>> getByCustomerIDAsync(int customerID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(Lead data)
        {
            var lead = new Lead();
            try
            {
                if (data != null)
                {
                    lead = new Lead
                    {
                        DateCreated = DateTime.Now,
                        UserCreated = data.UserCreated,
                        FirstName = data.FirstName,
                        Address = data.Address,
                        Email = data.Email,
                        Gender = data.Gender,
                        Image = data.Image,
                        LastName = data.LastName,
                        Phone = data.Phone,
                        Company=data.Company,
                        isCustomer=false
                    };
                    await _context.Leads.AddAsync(lead);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lead.ID;
        }

        public Task<int> insertListAsync(List<Lead> data)
        {
            throw new NotImplementedException();
        }

        public async Task<int> updateAsync(Lead data)
        {
            var lead = await _context.Leads.Where(x => x.ID == data.ID).SingleOrDefaultAsync();
            try
            {
                if (lead != null)
                {
                    lead.Image = data.Image;
                    lead.FirstName = data.FirstName;
                    lead.Phone = data.Phone;
                    lead.LastName = data.LastName;
                    lead.DateModified = DateTime.Now;
                    lead.UserModified = data.UserModified;
                    lead.Gender = data.Gender;
                    lead.Email = data.Email;
                    lead.Address = data.Address;
                    lead.isCustomer = data.isCustomer;



                    _context.Leads.Update(lead);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lead.ID;
        }
    }

}
