﻿using System;
using Newtonsoft.Json;

namespace DXEventsAPP.Facets
{
    public class LocationFacet
    {
        [JsonProperty("altitude")]
        public double Altitude { get; set; }
        
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
