using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface.DatabaseContracts;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Provider.DatabaseProviders
{
    public class AllDataExchangethroughRedisCache : IAllDataExchangethroughRedisCache
    {
        static ConfigurationOptions option = new ConfigurationOptions
        {
            AbortOnConnectFail = false,
            EndPoints = { "localhost" }
        };
        public ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(option);
        public List<PlaceAttributes> GetDataFromCache(string Key)
        {
            List<PlaceAttributes> data = new List<PlaceAttributes>();
            try
            {
                IDatabase db = redis.GetDatabase();
                string val = db.StringGet(Key);
                if (val == null)
                {
                    return null;
                }
                data = JsonConvert.DeserializeObject<List<PlaceAttributes>>(val);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                data = null;
            }
            return data;
        }

        public void SaveInCache(List<PlaceAttributes> PlaceData,string Key)
        {
            try
            {
                IDatabase db = redis.GetDatabase();
                string data = JsonConvert.SerializeObject(PlaceData);
                db.StringSet(Key, data, TimeSpan.FromHours(1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
