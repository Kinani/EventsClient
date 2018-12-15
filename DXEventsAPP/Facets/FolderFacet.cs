using System;
using Newtonsoft.Json;

namespace DXEventsAPP.Facets
{
    public class FolderFacet
    {
        [JsonProperty("childCount")]
        public long ChildCount { get; set; }
    }
}
