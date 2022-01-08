using CastillePCRTestManagement.Db;
using CastillePCRTestManagement.Models;
using CastillePCRTestManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Repository.Implementation
{
    public class TestBookingRepository : ITestBooking
    {
        private readonly ILogger<TestBookingRepository> _logger;
        public readonly AppDBContext _dbContext;
       

        public TestBookingRepository(ILogger<TestBookingRepository> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _dbContext = appDBContext;
        }

        public async Task<bool> BookTest(BookingInformation booking)
        {
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
            bool flag = false;

            try
            {
                //Asynchronously wait to enter the Semaphore. If no-one has been granted access to the Semaphore, code execution will proceed, otherwise this thread waits here until the semaphore is released 
                await semaphoreSlim.WaitAsync();

                booking.CreateDate = DateTime.Now;
                var result = _dbContext.BookingInformation.Add(booking);
                var bookingMasterObject = await _dbContext.BookingMaster.Where(a => a.Date == booking.BookingDate && a.Location == booking.Location).FirstOrDefaultAsync();

                bookingMasterObject.UsedSpace = bookingMasterObject.UsedSpace + 1;

                _dbContext.BookingMaster.Update(bookingMasterObject);


                await _dbContext.SaveChangesAsync();
                flag = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TestBookingRepository class, BookTest Method. Message : {ex.Message}");
            }
            return flag;
        }

        public async Task<List<BookingInformation>> GetAll()
        {
            List<BookingInformation> bookings = new List<BookingInformation>();
            try
            {
                bookings = await _dbContext.BookingInformation.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TestBookingRepository class, GetAll Method. Message : {ex.Message}");
            }
            return bookings;
        }

        public async Task<bool> CancelTest(long id)
        {
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
            bool flag = false;
            try
            {
                //Asynchronously wait to enter the Semaphore. If no-one has been granted access to the Semaphore, code execution will proceed, otherwise this thread waits here until the semaphore is released 
                await semaphoreSlim.WaitAsync();

                var booking = _dbContext.BookingInformation.Where(a => a.Id == id && string.IsNullOrEmpty(a.CancelledStatus )).FirstOrDefault();

                booking.CancelledStatus = "Yes";

                
                _dbContext.BookingInformation.Update(booking);

                var bookingMasterObject = _dbContext.BookingMaster.Where(a => a.Date == booking.BookingDate && a.Location == booking.Location).FirstOrDefault();


                bookingMasterObject.UsedSpace = bookingMasterObject.UsedSpace - 1;

                _dbContext.BookingMaster.Update(bookingMasterObject);


                await _dbContext.SaveChangesAsync();
                flag = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TestBookingRepository class, CancelTest Method. Message : {ex.Message}");
            }
            return flag;
        }

        public async Task<bool> IfExists(BookingInformation booking)
        {
            bool flag = false;
            try
            {
                var bookingObject = await _dbContext.BookingInformation.Where(a => a.BookingDate == booking.BookingDate && a.Location == booking.Location && a.FirstName == booking.FirstName && a.LastName == booking.LastName).FirstOrDefaultAsync();
                if(bookingObject != null)
                {
                    flag = true;
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TestBookingRepository class, IfExists Method. Message : {ex.Message}");
            }
            return flag;
        }

        public async Task<bool> CheckCancellationStatus(long id)
        {
            bool flag = false;
            try
            {
                var bookingObject = await _dbContext.BookingInformation.Where(a => a.Id == id && a.CancelledStatus != "Yes").FirstOrDefaultAsync();
                if (bookingObject != null)
                {
                    flag = true;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TestBookingRepository class, CheckCancellationStatus Method. Message : {ex.Message}");
            }
            return flag;
        }

        public async Task<bool> IfExistsID(long id)
        {
            bool flag = false;
            try
            {
                var bookingObject = await _dbContext.BookingInformation.Where(a => a.Id == id).FirstOrDefaultAsync();
                if (bookingObject != null)
                {
                    flag = true;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TestBookingRepository class, IfExists Method. Message : {ex.Message}");
            }
            return flag;
        }

        public async Task<bool> UploadResult(long id, string result)
        {
            bool flag = false;
            try
            {
                var bookingObject = await _dbContext.BookingInformation.Where(a => a.Id == id).FirstOrDefaultAsync();

                bookingObject.Result = result;
                bookingObject.ResultDate = DateTime.Now;

                await _dbContext.SaveChangesAsync();
                flag = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TestBookingRepository class, IfExists Method. Message : {ex.Message}");
            }
            return flag;
        }
    }
}
