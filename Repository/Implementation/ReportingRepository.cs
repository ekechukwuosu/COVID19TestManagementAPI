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
                foreach (var item in _dbContext.BookingMaster)
                {
                    Reporting r = new Reporting();
                    r.Date = item.Date;
                    r.Location = item.Location;
                    r.Capacity = item.Space;
                    r.CancelledBookings = _dbContext.BookingInformation.Where(a => a.BookingDate == item.Date && a.Location == item.Location && a.CancelledStatus == "Yes").Count();
                    r.ActualBookings = _dbContext.BookingInformation.Where(b => b.BookingDate == item.Date && b.Location == item.Location && b.CancelledStatus != "Yes").Count();
                    r.CompletedBookings = _dbContext.BookingInformation.Where(c => c.BookingDate == item.Date && c.Location == item.Location && !string.IsNullOrEmpty(c.Result)).Count();
                    r.PositiveCases = _dbContext.BookingInformation.Where(d => d.BookingDate == item.Date && d.Location == item.Location && d.Result == "Positive").Count();
                    r.NegativeCases = _dbContext.BookingInformation.Where(e => e.BookingDate == item.Date && e.Location == item.Location && e.Result == "Negative").Count();

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
