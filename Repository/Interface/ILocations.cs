using CastillePCRTestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastillePCRTestManagement.Repository.Interface
{
    public interface ILocations
    {
        Task<List<Locations>> GetLocations();
    }
}
