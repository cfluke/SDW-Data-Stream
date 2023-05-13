using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCPlanetaryKIndex1MJSON
    {
        [JsonProperty("time_tag")]
        [JsonPropertyName("time_tag")]
        public DateTime? TimeTag { get; set; }

        [JsonProperty("kp_index")]
        [JsonPropertyName("kp_index")]
        public int? KpIndex { get; set; }

        [JsonProperty("estimated_kp")]
        [JsonPropertyName("estimated_kp")]
        public double? EstimatedKp { get; set; }

        [JsonProperty("kp")]
        [JsonPropertyName("kp")]
        public string Kp { get; set; }
    }
}
