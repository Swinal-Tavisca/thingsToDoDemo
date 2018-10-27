using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using ThingsToDoProject.Model;
using ThingsToDoProject.Core.Provider;
using ThingsToDoProject.Core.Translater;

namespace ThingsToDoProject.Core.Provider
{
    public class GetInsideAirportData : IGetData
    {
        private readonly IHttpClientFactory _httpClientFactory;
        IConfiguration _iconfiguration;

        public GetInsideAirportData(IHttpClientFactory httpClientFactory , IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _iconfiguration = configuration;
        }
        public async Task<List<PlaceAttributes>> GetData(LocationAttributes Position , String DeparturePlace, String ArrivalDateTime, String DepartureDateTime, String PointOfInterest)
        {
            try
            {
                //using (HttpClient client = new HttpClient())
                //{
                    var client = _httpClientFactory.CreateClient(Constants.GoogleClient);
                    Uri endpoint = client.BaseAddress; // Returns GoogleApi
                    var Key = _iconfiguration["GoogleAPI"];
                    //var Url = endpoint.ToString() + "maps/api/place/nearbysearch/json?location=18.579343,73.9089168&radius=1000&type=" + PointOfInterest + "&key=" + Key;
                    var Url = endpoint.ToString() + "maps/api/place/nearbysearch/json?location=" + Position.LatitudePosition + "," + Position.LongitudePosition + "&radius=1000&type=" + PointOfInterest  + "&key=" + Key;
                    var client1 = _httpClientFactory.CreateClient();
                    var response = await client1.GetAsync(Url);

                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    RootobjectOfData data = JsonConvert.DeserializeObject<RootobjectOfData>(responseBody);
                    List<PlaceAttributes> Data = data.results.TransalateData(Key, endpoint);
                return Data;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
    
    //public static class Translator
    //{
    //    public static List<DataAttributes> GetTranslatedData(this JArray result)
    //    {
    //        return null;
    //    }
    //}
}
