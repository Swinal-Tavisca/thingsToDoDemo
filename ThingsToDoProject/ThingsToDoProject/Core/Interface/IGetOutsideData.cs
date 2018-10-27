using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Interface
{
    public interface IGetOutsideData
    {
        Task<List<PlaceAttributes>> GetAllData(String DeparturePlace, String ArrivalDateTime, String DepartureDateTime, String PointOfInterest);
    }
}
