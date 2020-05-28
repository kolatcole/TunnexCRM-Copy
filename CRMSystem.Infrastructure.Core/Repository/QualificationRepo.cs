using CRMSystem.Domains;
using CRMSystem.Domains.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Infrastructure
{
    public class QualificationRepo : IRepo<Qualification>
    {
        public Task<int> deleteAsync(Qualification data)
        {
            throw new NotImplementedException();
        }

        public Task<List<Qualification>> getAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Qualification> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Qualification>> getByCustomerIDAsync(int customerID)
        {
            throw new NotImplementedException();
        }

        public Task<int> insertAsync(Qualification data)
        {
            //var qual = new Qualification();
            //try
            //{
            //    if (data != null)
            //    {

            //        qual = new Qualification
            //        {

            //            Name = data.Name,
            //            Status = data.Status,
            //            StartDate = data.StartDate,
            //            EndDate = data.EndDate,
            //            EmployeeID = data.EmployeeID
            //        };
            //        await _context.Qua.AddAsync(qual);
            //        await _context.SaveChangesAsync();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return payment.ID;
            throw new NotImplementedException();
        }

        public Task<int> insertListAsync(List<Qualification> data)
        {
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(Qualification data)
        {
            throw new NotImplementedException();
        }
    }
}
