using CastillePCRTestManagement.Models;
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
    public class AdministrationController : ControllerBase
    {
        private readonly ILabAdministration _labAdministration;
        public AdministrationController(ILabAdministration labAdministration)
        {
            _labAdministration = labAdministration;
        }

        // POST api/<LabAdministrationController>
        [HttpPost("AddAllocation")]
        public async Task<IActionResult> Post([FromBody] BookingMaster bookingMaster)
        {
            try
            {
                var notification = await _labAdministration.AddAllocation(bookingMaster);

                return Ok(notification);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message ?? ex.InnerException.Message });
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAllocations()
        {
            try
            {
                var locations = await _labAdministration.GetAll();

                return Ok(locations);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message ?? ex.InnerException.Message });
            }

        }
        [HttpPost("CheckAvailability")]
        public async Task<IActionResult> CheckAvailability([FromBody] BookingInformation booking)
        {
            try
            {
                var notification = await _labAdministration.CheckAvailability(booking);

                return Ok(notification);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message ?? ex.InnerException.Message });
            }
        }
    }
}
