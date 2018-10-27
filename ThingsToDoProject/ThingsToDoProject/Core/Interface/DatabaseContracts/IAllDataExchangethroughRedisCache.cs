using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Interface.DatabaseContracts
{
    public interface IAllDataExchangethroughRedisCache
    {
        List<PlaceAttributes> GetDataFromCache(string Key);
        void SaveInCache(List<PlaceAttributes> PlaceData, string Key);
    }
}
