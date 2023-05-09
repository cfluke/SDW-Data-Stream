using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSADataStreams
{
    // NOAASWPCSunspotJSON myDeserializedClass = JsonConvert.DeserializeObject<List<NOAASWPCSunspotJSON>>(myJsonResponse);
    public class NOAASWPCSunspotJSON
    {
        public DateTime time_tag { get; set; }
        public DateTime Obsdate { get; set; }
        public string Obstime { get; set; }
        public int Station { get; set; }
        public string Observatory { get; set; }
        public string Type { get; set; }
        public int Quality { get; set; }
        public int? Region { get; set; }
        public int Latitude { get; set; }
        public int Report_Longitude { get; set; }
        public int Longitude { get; set; }
        public string Report_Location { get; set; }
        public string Location { get; set; }
        public int Carlon { get; set; }
        public int Extent { get; set; }
        public int Area { get; set; }
        public int Numspot { get; set; }
        public int Zurich { get; set; }
        public int Penumbra { get; set; }
        public int Compact { get; set; }
        public string Spotclass { get; set; }
        public int Magcode { get; set; }
        public string Magclass { get; set; }
        public int Obsid { get; set; }
        public int Report_Status { get; set; }
        public int ValidSpotClass { get; set; }
    }


}
