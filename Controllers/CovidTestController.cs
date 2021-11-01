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
    public class CovidTestController : ControllerBase
    {
        private readonly ITestBooking _testBooking;
        private readonly ILabAdministration _labAdministration;
        public CovidTestController(ITestBooking testBooking, ILabAdministration labAdministration)
        {
            _testBooking = testBooking;
            _labAdministration = labAdministration;
        }
        // POST api/<CovidTestController>
        [HttpPost("BookTest")]
        public async Task<IActionResult> BookTest([FromBody] BookingInformation booking)
        {
            string notification = default;
            try
            {
                if(!string.IsNullOrEmpty(booking.FirstName) && !string.IsNullOrEmpty(booking.LastName) && !string.IsNullOrEmpty(booking.Location) && !string.IsNullOrEmpty(booking.BookingDate.ToString()))
                {
                    var isAvailable = await _labAdministration.CheckAvailability(booking);
                    if (isAvailable == true)
                    {
                        var ifExists = _testBooking.IfExists(booking).Result;
                        if (ifExists == false)
                        {
                            var result = await _testBooking.BookTest(booking);
                            notification = result.ToString();
                        }
                        else
                        {
                            notification = $"A booking with the same BookingDate, Location, FirstName and LastName exists";
                        }
                    }
                    else
                    {
                        notification = $"The date selected '{booking.BookingDate}' has not available test slots";
                    }
                }
                else
                {

                    notification = $"Invalid input. Check FirstName, LastName, Location and Date";
                }
                     

                return Ok(new { message = notification });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message ?? ex.InnerException.Message });
            }
        }
        [HttpPatch("CancelTest/{id}")]
        public async Task<IActionResult> CancelTest(long id)
        {
            string notification = default;
            try
            {
                var status = await _testBooking.CheckCancellationStatus(id);
                if(status == true)
                {
                    var flag = await _testBooking.CancelTest(id);
                    notification = flag.ToString();
                }
                else
                {
                    notification = $"The test booking with ID {id} does not exist or has been previously cancelled";
                }                               

                return Ok(new { message = notification });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message ?? ex.InnerException.Message });
            }
        }
        [HttpPatch("UploadResult/{id}/{result}")]
        public async Task<IActionResult> UploadResult(long id, string result)
        {
            string notification = default;
            try
            {
                var status = await _testBooking.IfExistsID(id);
                if (status == true)
                {
                    var flag = await _testBooking.UploadResult(id, result);
                    notification = flag.ToString();
                }
                else
                {
                    notification = $"The booking with ID {id} does not exist";
                }

                return Ok(new { message = notification });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message ?? ex.InnerException.Message });
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                var testBokings = await _testBooking.GetAll();

                return Ok(testBokings);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message ?? ex.InnerException.Message });
            }

        }
    }
}
