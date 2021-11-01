using CastillePCRTestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Repository.Interface
{
    public interface ITestBooking
    {
        Task<bool> BookTest(BookingInformation booking);
        Task<bool> CancelTest(long id);
        Task<List<BookingInformation>> GetAll();
        Task<bool> IfExists(BookingInformation booking);
        Task<bool> IfExistsID(long id);
        Task<bool> CheckCancellationStatus(long id);
        Task<bool> UploadResult(long id, string result);
    }
}
