using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXEventsAPP.Model
{
    public class session
    {
        // Might be merged with dxevent
        public string id { get; set; }
        public string eventid { get; set; }
        public string sessionname { get; set; }
        public string sessiontime { get; set; }
        public string endtime { get; set; }
        public string speaker { get; set; }
        public string description { get; set; }


    }
}
