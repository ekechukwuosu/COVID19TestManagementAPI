using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Models
{
    [Index(nameof(Location))]
    [Index(nameof(BookingDate))]
    [Index(nameof(BookingDate), nameof(Location))]
    [Index(nameof(BookingDate), nameof(Location), nameof(FirstName), nameof(LastName))]
    [Index(nameof(Id), nameof(CancelledStatus))]
    public class BookingInformation: Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string TestType { get; set; }
        public DateTime BookingDate { get; set; }
        public string CancelledStatus { get; set; }
        public string Result { get; set; }
        public DateTime ResultDate { get; set; }
        public DateTime CreateDate { get; set; }
       
    }
}
