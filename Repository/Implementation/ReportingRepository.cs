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
    public class ReportingRepository : IReporting
    {
        private readonly ILogger<ReportingRepository> _logger;
        public readonly AppDBContext _dbContext;

        public ReportingRepository(ILogger<ReportingRepository> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _dbContext = appDBContext;
        }
        public async Task<List<Reporting>> GetReport()
        {
            List<Reporting> report = new List<Reporting>();
            
            try
            {
                var allocations = await _dbContext.BookingMaster.ToListAsync();
                var allbookings = await _dbContext.BookingInformation.ToListAsync();
                foreach (var item in allocations)
                {
                    Reporting r = new Reporting();
                    r.Date = item.Date;
                    r.Location = item.Location;
                    r.Capacity = item.Space;
                    r.CancelledBookings = allbookings.Where(a => a.BookingDate == item.Date && a.Location == item.Location && a.CancelledStatus == "Yes").Count();
                    r.ActualBookings = allbookings.Where(b => b.BookingDate == item.Date && b.Location == item.Location && b.CancelledStatus != "Yes").Count();
                    r.CompletedBookings = allbookings.Where(c => c.BookingDate == item.Date && c.Location == item.Location && !string.IsNullOrEmpty(c.Result)).Count();
                    r.PositiveCases = allbookings.Where(d => d.BookingDate == item.Date && d.Location == item.Location && d.Result == "Positive").Count();
                    r.NegativeCases = allbookings.Where(e => e.BookingDate == item.Date && e.Location == item.Location && e.Result == "Negative").Count();

                    report.Add(r);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in ReportingRepository class, GetReport Method. Message : {ex.Message}");
            }
            return report;
        }
    }
}
