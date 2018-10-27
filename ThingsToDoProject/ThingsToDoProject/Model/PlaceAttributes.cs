using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThingsToDoProject.Model
{
    public class PlaceAttributes
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool OpenClosedStatus { get; set; }
        public string Image { get; set; }
        public string PlaceID { get; set; }
        public float Rating { get; set; }
        public string Vicinity { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public string PhoneNumber { get; set; }
        public string[] WeekDaysDetail { get; set; }
        public List<AllReview> Reviews { get; set; }

        public string GoogleMapUrl { get; set; }
        public string Website { get; set; }
        public string Duration { get; set; }
        public string Distance { get; set; }

    }

    /*Start*/
    public class RootobjectOfData
    {
        public object[] html_attributions { get; set; }
        public string next_page_token { get; set; }
        public Result[] results { get; set; }
        public string status { get; set; }
    }

    //public class Result
    //{
    //    public Geometry geometry { get; set; }
    //    public string icon { get; set; }
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public Opening_Hours opening_hours { get; set; }
    //    public Photo[] photos { get; set; }
    //    public string place_id { get; set; }
    //    public Plus_Code plus_code { get; set; }
    //    public string reference { get; set; }
    //    public string scope { get; set; }
    //    public string[] types { get; set; }
    //    public string vicinity { get; set; }
    //    public float rating { get; set; }
    //    public int price_level { get; set; }
    //}

    //public class Geometry
    //{
    //    public Location location { get; set; }
    //    public Viewport viewport { get; set; }
    //}

    //public class Location
    //{
    //    public float lat { get; set; }
    //    public float lng { get; set; }
    //}

    //public class Viewport
    //{
    //    public Northeast northeast { get; set; }
    //    public Southwest southwest { get; set; }
    //}

    //public class Northeast
    //{
    //    public float lat { get; set; }
    //    public float lng { get; set; }
    //}

    //public class Southwest
    //{
    //    public float lat { get; set; }
    //    public float lng { get; set; }
    //}

    //public class Opening_Hours
    //{
    //    public bool open_now { get; set; }
    //}

    //public class Plus_Code
    //{
    //    public string compound_code { get; set; }
    //    public string global_code { get; set; }
    //}

    //public class Photo
    //{
    //    public int height { get; set; }
    //    public string[] html_attributions { get; set; }
    //    public string photo_reference { get; set; }
    //    public int width { get; set; }
    //}




    /*End*/
    public class Rootobject
    {
        public object[] html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }

    }

    public class Result
    {
        public Address_Components[] address_components { get; set; }
        public string adr_address { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public Opening_Hours opening_hours { get; set; }
        public Photo[] photos { get; set; }
        public string place_id { get; set; }
        public Plus_Code plus_code { get; set; }
        public float rating { get; set; }
        public string reference { get; set; }
        public Review[] reviews { get; set; }
        public string scope { get; set; }
        public string[] types { get; set; }
        public string url { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }
    }
   
    public class Geometry
    {
        public Location location { get; set; }
        public Viewport viewport { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Northeast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Southwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Opening_Hours
    {
        public bool open_now { get; set; }
        public Period[] periods { get; set; }
        public string[] weekday_text { get; set; }
    }

    public class Period
    {
        public Close close { get; set; }
        public Open open { get; set; }
    }

    public class Close
    {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class Open
    {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class Plus_Code
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class Address_Components
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public string[] html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

    public class Review
    {
        public string author_name { get; set; }
        public string author_url { get; set; }
        public string language { get; set; }
        public string profile_photo_url { get; set; }
        public int rating { get; set; }
        public string relative_time_description { get; set; }
        public string text { get; set; }
        public int time { get; set; }
    }
    public class AllReview
    {
        public string author_name { get; set; }
        public int rating { get; set; }
        public string text { get; set; }
    }

}
