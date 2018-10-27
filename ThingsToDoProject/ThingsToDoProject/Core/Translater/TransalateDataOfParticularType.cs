using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Translater
{
    public static class TransalateDataOfParticularType
    {
        public static List<PlaceAttributes> TransalateData(this Result[] results, string Key , Uri Url)
        {
            List<PlaceAttributes> DataDetails = new List<PlaceAttributes>();

            for (int Index = 0; Index < results.Length; Index++)
            {
                //DataDetails.Add(new PlaceAttributes
                //{
                PlaceAttributes data = new PlaceAttributes();
                data.Name = results[Index].name ?? results[Index].name;
                data.Address = results[Index].formatted_address ?? results[Index].formatted_address;
                data.OpenClosedStatus = results[Index].opening_hours == null ? false : results[Index].opening_hours.open_now;
                data.Image = results[Index].photos == null ? null : Url + "maps/api/place/photo?maxwidth=400&photoreference=" + results[Index].photos[0].photo_reference + "&key=" + Key;
                data.PlaceID = results[Index].place_id == null ? null : results[Index].place_id;
                data.Rating = results[Index].rating == 0 ? 0 : results[Index].rating;
                data.Vicinity = results[Index].vicinity == null ? null : results[Index].vicinity;
                data.Latitude = results[Index].geometry.location.lat == 0 ? 0 : results[Index].geometry.location.lat;
                data.Longitude = results[Index].geometry.location.lng == 0 ? 0 : results[Index].geometry.location.lng;
                   // WeekDaysDetail = results[Index].opening_hours.weekday_text,//results.reviews == null ? null : results.reviews.ToList(),
                   // GoogleMapUrl = results[Index].url,
                    //Website = results[Index].website,

                //});
                DataDetails.Add(data);
            }

            //List<DataAttributes> StoreDetails = new List<DataAttributes>();
            //for (var index = 0; index < results.Count; index++)
            //{
            //    DataAttributes store = new DataAttributes();

            //    var resultObject = (JObject)results[index];
            //    store.Name = resultObject["name"].Value<string>();
            //    try{ store.Address = resultObject["formatted_address"].Value<string>();}
            //    catch{ store.Address = "Address Not Available";}

            //    try{ var openingStatus = resultObject["opening_hours"].Value<JObject>();
            //         store.OpenClosedStatus = openingStatus["open_now"].Value<string>();}
            //    catch{store.OpenClosedStatus = "Status Not Available";}

            //    try{ var photos = resultObject["photos"].Value<JArray>();
            //        var photosObject = (JObject)photos[0];
            //        store.PhotoReference = photosObject["photo_reference"].Value<string>();}
            //    catch{ store.PhotoReference = "Reference Not Available";}

            //    try { store.PlaceID = resultObject["place_id"].Value<string>(); }
            //    catch { store.PlaceID = "Place ID is Not Available"; }

            //    try{store.Rating = Convert.ToInt32(resultObject["rating"].Value<string>());}
            //    catch{store.Rating = -1;}

            //    //try{
            //    //    store.AllType = resultObject["types"].Value<JArray>();
            //    //    store.Type = Type;}
            //    //catch{store.Type = Type;}

            //    try{ store.Vicinity = resultObject["vicinity"].Value<string>();}
            //    catch { store.Vicinity = "Not Available"; }
            //    var geometry = resultObject["geometry"].Value<JObject>();
            //    var location = geometry["location"].Value<JObject>();
            //    store.Longitude = location["lng"].Value<string>();
            //    store.Latitude = location["lat"].Value<string>();
            //    StoreDetails.Add(store);
            //}
            return DataDetails;
        }
    }
}
