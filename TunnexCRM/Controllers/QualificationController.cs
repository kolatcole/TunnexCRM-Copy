using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMSystem.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IRepo<Qualification> _repo;
        public QualificationController(IRepo<Qualification> repo)
        {
            _repo = repo;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("Save")]
        public async Task<IActionResult> Save(Qualification data)
        {
            var result = await _repo.insertAsync(data);
            return Ok(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Qualification data)
        {
            var result = await _repo.updateAsync(data);
            return Ok(result);
        }

    }
}
