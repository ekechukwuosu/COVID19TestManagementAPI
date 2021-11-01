using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Models
{
    [Index(nameof(Location))]
    [Index(nameof(Date))]
    [Index(nameof(Date), nameof(Location))]   
    public class BookingMaster:Entity
    {
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public long Space { get; set; }
        public long UsedSpace { get; set; }
    }
}
