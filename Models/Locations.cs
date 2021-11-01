using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Models
{
    [Index(nameof(Location))]
    public class Locations:Entity
    {
        public string Location { get; set; }
    }
}
