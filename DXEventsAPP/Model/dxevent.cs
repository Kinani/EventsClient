using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXEventsAPP.Model
{
    public class dxevent
    {
        public string id { get; set; }

        [JsonProperty(PropertyName = "eventname")]
        public string eventname { get; set; }

        [JsonProperty(PropertyName = "eventdate")]
        public string eventdate { get; set; }
       
        [JsonProperty(PropertyName = "eventplace")]
        public string eventplace { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }

        [JsonProperty(PropertyName = "registerationlink")]
        public string registerationlink { get; set; }
        
        [JsonProperty(PropertyName = "complete")]
        public bool complete { get; set; }

    }
}
