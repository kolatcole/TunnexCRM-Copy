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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;
        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        /// <summary>
        /// Debtor's List
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDebtorsList")]
        public async Task<IActionResult> GetDebtorsList()
        {
            var result = await _service.getDebtorInvoice();
            return Ok(result);
        }
    }
}