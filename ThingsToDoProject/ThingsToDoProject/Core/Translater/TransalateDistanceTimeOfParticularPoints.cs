using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Translater
{
    public static class TransalateDistanceTimeOfParticularPoints
    {
        public static DistanceTimeAttributes TransalateDistanceTime(this Route[] result)
        {
            try
            {
                DistanceTimeAttributes PlaceDetails = new DistanceTimeAttributes();
                PlaceDetails.Duration = result[0].legs[0].duration.text;
                PlaceDetails.Distance = result[0].legs[0].distance.text;
                return PlaceDetails;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
