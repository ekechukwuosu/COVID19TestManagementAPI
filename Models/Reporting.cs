using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Models
{
    public class Reporting: Entity
    {
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public long Capacity { get; set; }
        public long ActualBookings { get; set; }
        public long CancelledBookings { get; set; }
        public long CompletedBookings { get; set; }
        public long PositiveCases { get; set; }
        public long NegativeCases { get; set; }
    }
}
