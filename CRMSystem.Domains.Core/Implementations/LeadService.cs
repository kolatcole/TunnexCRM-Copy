using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public class LeadService : ILeadService
    {
        private readonly IRepo<Lead> _lRepo;
        private readonly IRepo<Message> _mRepo;
        public LeadService(IRepo<Lead> lRepo,IRepo<Message> mRepo)
        {
            _lRepo = lRepo;
            _mRepo = mRepo;
        }

        public async Task<List<Lead>> getAllLeads()
        {
            var result = await _lRepo.getAllAsync();
            return result;
        }

        public async Task<Lead> getLeadByID(int ID)
        {
            var result = await _lRepo.getAsync(ID);
            return result;
        }

        public async Task<int> SaveLeadAsync(Lead data)
        {
            int LID = await _lRepo.insertAsync(data);

            List<Message> messages = new List<Message>();
            foreach (var message in data.Message)
            {
                message.LeadID = LID;
                messages.Add(message);
            }

            await _mRepo.insertListAsync(messages);
            return LID;

        }

        public Task<int> UpdateLeadAsync(Lead data)
        {
            throw new NotImplementedException();
        }
    }
}
