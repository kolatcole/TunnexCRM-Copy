﻿using CRMSystem.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Infrastructure
{
    public class SaleRepo : IRepo<Sale>
    {
        private readonly TContext _context;
        public SaleRepo(TContext context)
        {
            _context = context;
        }
        public Task<int> deleteAsync(Sale data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sale>> getAllAsync()
        {

            try
            {
                var sale = await _context.Sales.ToListAsync();
                return sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<Sale> getAsync(int ID)
        {
            try
            {
                var sale = await _context.Sales.Where(x => x.ID == ID).FirstOrDefaultAsync();
                return sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> insertAsync(Sale data)
        {

          //  Sale obj = new Sale();
            try
            {
                
                   Sale obj = new Sale
                    {
                       CartID=data.CartID,
                       InvoiceID=data.InvoiceID,
                      
                        DateCreated = DateTime.Now,
                        UserCreated = data.UserModified,
                        CustomerID = data.CustomerID
                        
                    };
                    await _context.Sales.AddAsync(obj);
                    await _context.SaveChangesAsync();
                    return obj.ID;
                
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Task<int> insertListAsync(List<Sale> data)
        {
            throw new NotImplementedException();
        }

        public async Task<int> updateAsync(Sale data)
        {
            int ID = 0;
            var sale = await _context.Sales.FindAsync(data.ID);
            try
            {
                if (sale != null)
                {
                    sale.InvoiceID = data.InvoiceID;
                    sale.DateModified = data.DateModified;
                    sale.UserModified = data.UserModified;


                    _context.Sales.Update(sale);
                    ID = await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sale.ID;
        }
    }
}