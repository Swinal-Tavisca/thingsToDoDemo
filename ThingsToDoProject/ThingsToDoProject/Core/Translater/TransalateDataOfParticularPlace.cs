using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Translater
{
    public static class TransalateDataOfParticularPlace
    {

        public static PlaceAttributes TransalatePlaceData(this Result results, string Key, Uri Url)
        {
            
            PlaceAttributes PlaceDetails = new PlaceAttributes();
            PlaceDetails.Name = results.name;
            PlaceDetails.Address = results.formatted_address;
            PlaceDetails.OpenClosedStatus = results.opening_hours.open_now;
            PlaceDetails.Image = Url + "maps/api/place/photo?maxwidth=400&photoreference=" + results.photos[0].photo_reference + "&key=" + Key;
            PlaceDetails.PlaceID = results.place_id;
            PlaceDetails.Rating = results.rating;
            PlaceDetails.Vicinity = results.vicinity;
            PlaceDetails.Latitude = results.geometry.location.lat;
            PlaceDetails.Longitude = results.geometry.location.lng;
            PlaceDetails.PhoneNumber = results.formatted_phone_number;
            PlaceDetails.Reviews = GetReviews(results.reviews);
            PlaceDetails.WeekDaysDetail = results.opening_hours.weekday_text;//results.reviews == null ? null : results.reviews.ToList(),
            PlaceDetails.GoogleMapUrl = results.url;
            PlaceDetails.Website = results.website;
            return PlaceDetails;
        }

        private static List<AllReview> GetReviews(Review[] reviews)
        {
            int count = 0;
            return reviews.Select(x => new AllReview()
            {
                author_name = reviews[count].author_name,
                text = reviews[count].text,
                rating = reviews[count++].rating,
            }).ToList();
        }
    }
}