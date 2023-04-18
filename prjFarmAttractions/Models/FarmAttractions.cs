using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFarmAttractions.Models
{
    public class FarmAttractions
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Introduction { get; set; }
        public string TrafficGuidlines { get; set; }
        public string Address { get; set; }
        public string OpenHours { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Photo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}