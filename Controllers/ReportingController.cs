using CastillePCRTestManagement.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CastillePCRTestManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IReporting _reporting;
        public ReportingController(IReporting reporting)
        {
            _reporting = reporting;
        }
        // GET: api/<ReportingController>
        [HttpGet("GetReports")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var reports = await _reporting.GetReport();

                return Ok(reports);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message ?? ex.InnerException.Message });
            }

        }

    }
}
