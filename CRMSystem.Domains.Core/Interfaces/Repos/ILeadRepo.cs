using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public interface ILeadRepo
    {
        Task<bool> ConvertLeadtoCustomer(Lead data);
    }
}
