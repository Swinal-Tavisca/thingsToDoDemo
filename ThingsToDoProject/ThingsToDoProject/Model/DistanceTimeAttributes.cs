using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThingsToDoProject.Model
{
    public class DistanceTimeAttributes
    {
        public string Duration { get; set; }
        public string Distance { get; set; }
    }
    /*Google Distance Time Api*/
    public class RootobjectOfDirection
    {
        public Route[] routes { get; set; }
    }
    public class Route
    {
        public Leg[] legs { get; set; }
    }
    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }
    /*End Google Distance Time Api*/
}
