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
    public class LocationsController : ControllerBase
    {
        private readonly ILocations _locations;
        public LocationsController(ILocations locations)
        {
            _locations = locations;
        }
        [HttpGet("GetAllLocations")]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var locations = await _locations.GetLocations();

                return Ok(locations);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message ?? ex.InnerException.Message });
            }

        }
        
    }
}
