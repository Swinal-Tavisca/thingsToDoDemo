using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using ThingsToDoProject.Core.Translater;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Provider
{
    public class GetDistanceTimeOfParticularPlace : IGetDistanceTime
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGetLatitudeLongitude _getLatitudeLongitude;
        IConfiguration _iconfiguration;

        public GetDistanceTimeOfParticularPlace(IHttpClientFactory httpClientFactory, IConfiguration configuration, IGetLatitudeLongitude getLatitudeLongitude)
        {
            _httpClientFactory = httpClientFactory;
            _iconfiguration = configuration;
            _getLatitudeLongitude = getLatitudeLongitude;
        }
        public async Task<DistanceTimeAttributes> GetDistanceTime(string DeparturePlace,float DestinationLatitude , float DestinationLongitude)
        {
            try
            {
                LocationAttributes SourcePosition = _getLatitudeLongitude.Get(DeparturePlace);
                var client = _httpClientFactory.CreateClient("GoogleClient");
                Uri endpoint = client.BaseAddress; // Returns GoogleApi
                var Key = _iconfiguration["GoogleAPI"];
                var Url = endpoint.ToString() + "maps/api/directions/json?origin=" + SourcePosition.LatitudePosition + "," + SourcePosition.LongitudePosition + "&destination="+ DestinationLatitude +","+ DestinationLongitude + " &key=" + Key;
                var client1 = _httpClientFactory.CreateClient();
                var response = await client1.GetAsync(Url);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                RootobjectOfDirection data = JsonConvert.DeserializeObject<RootobjectOfDirection>(responseBody);
                DistanceTimeAttributes Data = data.routes.TransalateDistanceTime();
                return Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
    
}
