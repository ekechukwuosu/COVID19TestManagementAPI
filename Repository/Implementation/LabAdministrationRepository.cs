using CastillePCRTestManagement.Db;
using CastillePCRTestManagement.Models;
using CastillePCRTestManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Repository.Implementation
{
    public class LabAdministrationRepository : ILabAdministration
    {
        private readonly ILogger<LabAdministrationRepository> _logger;
        public readonly AppDBContext _dbContext;
        public LabAdministrationRepository(ILogger<LabAdministrationRepository> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _dbContext = appDBContext;
        }
        public async Task<bool> AddAllocation(BookingMaster bookingMaster)
        {
            bool flag = false;
            try
            {
                var result = _dbContext.BookingMaster.Add(bookingMaster);
                await _dbContext.SaveChangesAsync();
                flag = true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error in LabAdministrationRepository class, AddAllocation Method. Message : {ex.Message}");
            }
            return flag;
        }

        public async Task<List<BookingMaster>> GetAll()
        {
            List<BookingMaster> allocations = new List<BookingMaster>();
            try
            {
                allocations = await _dbContext.BookingMaster.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in LabAdministrationRepository class, GetAll Method. Message : {ex.Message}");
            }
            return allocations;
        }

        public async Task<bool> CheckAvailability(BookingInformation bookingInformation)
        {
            bool flag = false;
            try
            {
                var bookingmaster =  await _dbContext.BookingMaster.Where(a =>  a.Date == bookingInformation.BookingDate && a.Location == bookingInformation.Location).FirstOrDefaultAsync();
                if(bookingmaster != null)
                {
                    if (bookingmaster.UsedSpace < bookingmaster.Space)
                    {
                        flag = true;
                    }
                }               
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in LabAdministrationRepository class, CheckAvailability Method. Message : {ex.Message}");
            }
            return flag;
        }
    }
}
