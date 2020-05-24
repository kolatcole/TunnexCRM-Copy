using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMSystem.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.Presentation.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _service;
        public LeadController(ILeadService service)
        {
            _service = service;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Post(Lead data)
        {
            var result = await _service.SaveLeadAsync(data);
            return Ok(result);

        }

        [HttpGet("GetLeadByID/{ID}")]
        public async Task<IActionResult> GetLead(int ID)
        {
            var result = await _service.getLeadByID(ID);
            return Ok(result);

        }
        [HttpGet("GetAllLeads")]
        public async Task<IActionResult> GetAllLeads()
        {
            var result = await _service.getAllLeads();
            return Ok(result);

        }
    }
}