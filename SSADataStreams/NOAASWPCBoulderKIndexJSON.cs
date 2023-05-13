using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCBoulderKIndexJSON
    {
        [JsonProperty("time_tag")]
        [JsonPropertyName("time_tag")]
        public DateTime? TimeTag { get; set; }

        [JsonProperty("k_index")]
        [JsonPropertyName("k_index")]
        public double? KIndex { get; set; }
    }
}
