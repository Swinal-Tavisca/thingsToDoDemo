using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Interface
{
    public interface IGetData
    {
        Task<List<PlaceAttributes>> GetData(LocationAttributes Position, String DeparturePlace, String ArrivalDateTime, String DepartureDateTime, String PointOfInterest);
    }
}
