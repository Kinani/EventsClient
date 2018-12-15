using System;
using Newtonsoft.Json;

namespace DXEventsAPP.Facets
{
    public class ImageFacet
    {
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
