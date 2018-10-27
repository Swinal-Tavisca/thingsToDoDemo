using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Interface
{
    public interface IGetDistanceTime
    {
        Task<DistanceTimeAttributes> GetDistanceTime(string DeparturePlace, float DestinationLatitude, float DestinationLongitude);
    }
}
