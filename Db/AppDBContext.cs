using CastillePCRTestManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Db
{
    public class AppDBContext: DbContext
    {
        public DbSet<BookingInformation> BookingInformation { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<BookingMaster> BookingMaster { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }       
    }
}
