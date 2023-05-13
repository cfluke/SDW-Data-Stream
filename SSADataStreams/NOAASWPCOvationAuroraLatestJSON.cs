using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCOvationAuroraLatestJSON
    {
        [JsonProperty("Observation Time")]
        [JsonPropertyName("Observation Time")]
        public DateTime? ObservationTime { get; set; }

        [JsonProperty("Forecast Time")]
        [JsonPropertyName("Forecast Time")]
        public DateTime? ForecastTime { get; set; }

        [JsonProperty("Data Format")]
        [JsonPropertyName("Data Format")]
        public string DataFormat { get; set; }

        [JsonProperty("coordinates")]
        [JsonPropertyName("coordinates")]
        public List<List<int?>> Coordinates { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
