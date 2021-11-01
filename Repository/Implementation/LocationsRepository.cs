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
    public class LocationsRepository : ILocations
    {
        private readonly ILogger<LocationsRepository> _logger;
        public readonly AppDBContext _dbContext;

        public LocationsRepository(ILogger<LocationsRepository> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _dbContext = appDBContext;
        }

        public async Task<List<Locations>> GetLocations()
        {
            List<Locations> locations = new List<Locations>();
            try
            {
                locations = await _dbContext.Locations.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TestBooking class, GetLocations Method. Message : {ex.Message}");
            }
            return locations;

        }
    }
}
