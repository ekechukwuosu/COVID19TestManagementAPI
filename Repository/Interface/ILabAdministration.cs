using CastillePCRTestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Repository.Interface
{
    public interface ILabAdministration 
    {
        Task<bool> AddAllocation(BookingMaster bookingMaster);
        Task<List<BookingMaster>> GetAll();
        Task<bool> CheckAvailability(BookingInformation bookingInformation);

    }
}
