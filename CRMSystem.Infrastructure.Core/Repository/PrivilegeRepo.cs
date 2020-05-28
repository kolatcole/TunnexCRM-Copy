using CRMSystem.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Infrastructure
{
    public class PrivilegeRepo:IRepo<Privilege>
    {
        public readonly TContext _context;
        public PrivilegeRepo(TContext context)
        {
            _context = context;
        }

        public Task<int> deleteAsync(Privilege data)
        {
            throw new NotImplementedException();
        }

        public Task<List<Privilege>> getAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Privilege> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Privilege>> getByCustomerIDAsync(int customerID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(Privilege data)
        {
            var privilege = new Privilege();
            try
            {
                privilege = new Privilege
                {
                    Code = data.Code,
                    DateCreated = DateTime.Now,
                    UserCreated = data.UserCreated,
                    Name = data.Name,
                    Read=data.Read,
                    Write=data.Write,
                    RoleID=data.RoleID
                };

                await _context.Privileges.AddAsync(privilege);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return privilege.ID;
        }

        public async Task<int> insertListAsync(List<Privilege> data)
        {
            int ID = 0;
            
            try
            {


                await _context.Privileges.AddRangeAsync(data);
               ID= await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ID;
        }

        public Task<int> updateAsync(Privilege data)
        {
            throw new NotImplementedException();
        }
    }
}
