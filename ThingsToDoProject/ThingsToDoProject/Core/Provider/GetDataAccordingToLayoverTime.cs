using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using ThingsToDoProject.Core.Interface.DatabaseContracts;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Provider
{
    public class GetDataAccordingToLayoverTime: IGetDataAccordingToLayoverTime
    {

        private readonly IGetDistanceTime _getDistanceTime;
        private readonly IAllDataExchangethroughRedisCache _allDataExchangethroughRedisCache;

        public GetDataAccordingToLayoverTime(IGetDistanceTime getDistanceTime, IAllDataExchangethroughRedisCache allDataExchangethroughRedisCache)
        {
            _getDistanceTime = getDistanceTime;
            _allDataExchangethroughRedisCache = allDataExchangethroughRedisCache;
        }

        public async Task<List<PlaceAttributes>> GetFilterData(List<PlaceAttributes>AllData  , string DeparturePlace, int LayoverTime,string FilterKey)
        {
            try
            {
                List<PlaceAttributes> FilterData = new List<PlaceAttributes>();
                for(int Index = 0; Index < AllData.Count; Index++)
                {
                    DistanceTimeAttributes Journey = await _getDistanceTime.GetDistanceTime(DeparturePlace, AllData[Index].Latitude, AllData[Index].Longitude);
                    int TotalMinutes = 0;
                    int MinsPosition = Journey.Duration.IndexOf("m");
                    if (Journey.Duration.Contains("hour"))
                    {
                        int HourPosition = Journey.Duration.IndexOf("r");
                        int hour = Convert.ToInt32(Journey.Duration.Substring(0, Journey.Duration.IndexOf("h")));
                        int min = Convert.ToInt32(Journey.Duration.Substring(HourPosition+1, 2));
                        TotalMinutes = (hour*60) + min;
                    }
                    else
                    {
                        TotalMinutes = Convert.ToInt32(Journey.Duration.Substring(0, MinsPosition));
                    }
                    int CommutingTime = (2 * TotalMinutes) + 60;
                    int IsPossible = LayoverTime - CommutingTime;
                    if (IsPossible > 0 && LayoverTime >= CommutingTime){
                        PlaceAttributes data = new PlaceAttributes();
                        data.Name = AllData[Index].Name;
                        data.Address = AllData[Index].Address;
                        data.OpenClosedStatus = AllData[Index].OpenClosedStatus;
                        data.Image = AllData[Index].Image;
                        data.PlaceID = AllData[Index].PlaceID;
                        data.Rating = AllData[Index].Rating;
                        data.Vicinity = AllData[Index].Vicinity;
                        FilterData.Add(data);
                    }
                }
                _allDataExchangethroughRedisCache.SaveInCache(FilterData, FilterKey);
                return FilterData;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
