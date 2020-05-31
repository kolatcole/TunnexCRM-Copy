using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public class StaffSkillService : IStaffSkillService
    {
        private readonly IRepo<Assessment> _aRepo;
        private readonly IRepo<StaffSkill> _sRepo;

        public StaffSkillService(IRepo<Assessment> aRepo,IRepo<StaffSkill> sRepo)
        {

            _sRepo = sRepo;
            _aRepo = aRepo;
        }
        

        public async Task<int> SaveStaffSkill(StaffSkill data)
        {
            var SID = await _sRepo.insertAsync(data);
            return SID;

        }

        public async Task<int> UpdateStaffSkillAsync(StaffSkill data)
        {
            var skill = await _sRepo.getAsync(data.ID);

            var assessments = new List<Assessment>();
            var comp = 0;
            foreach (var assessment in data.Assessments)
            {
                comp += assessment.SAS;
                assessment.StaffSkillID = skill.ID;
                await _aRepo.insertAsync(assessment);
            }
            data.CompetencyValue = comp * 100;


            var SID = await _sRepo.updateAsync(data);
            return SID;
        }
    }
}
