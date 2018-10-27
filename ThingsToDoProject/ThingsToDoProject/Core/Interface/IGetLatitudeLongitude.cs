using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Interface
{
    public interface IGetLatitudeLongitude
    {
        LocationAttributes Get(string CityName);
    }
}
