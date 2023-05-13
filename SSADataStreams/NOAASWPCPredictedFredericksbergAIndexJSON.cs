using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCPredictedFredericksbergAIndexJSON
    {
        [JsonProperty("date")]
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonProperty("afred_1_day")]
        [JsonPropertyName("afred_1_day")]
        public int? Afred1Day { get; set; }

        [JsonProperty("afred_2_day")]
        [JsonPropertyName("afred_2_day")]
        public int? Afred2Day { get; set; }

        [JsonProperty("afred_3_day")]
        [JsonPropertyName("afred_3_day")]
        public int? Afred3Day { get; set; }
    }
}
