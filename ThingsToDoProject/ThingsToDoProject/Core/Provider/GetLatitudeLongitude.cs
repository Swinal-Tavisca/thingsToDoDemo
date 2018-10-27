using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Provider
{
    public class GetLatitudeLongitude : IGetLatitudeLongitude
    {
        public LocationAttributes Get(string CityName)
        {
            LocationAttributes Position = new LocationAttributes();
            Position.Address = CityName;
            var locationService = new GoogleLocationService(apikey: "AIzaSyA9v-ByUMauD8TazXdViq_f7RF-EHru86A");
            var Point = locationService.GetLatLongFromAddress(Position.Address);

            Position.LatitudePosition = Point.Latitude;
            Position.LongitudePosition = Point.Longitude;

            return Position;
        }
    }
}
