using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Interface
{
    public interface IGetDataAccordingToLayoverTime
    {
        Task<List<PlaceAttributes>> GetFilterData(List<PlaceAttributes> AllData, string DeparturePlace, int LayoverTime,string FilterKey);
    }
}
