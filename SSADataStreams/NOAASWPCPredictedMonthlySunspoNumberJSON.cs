using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCPredictedMonthlySunspoNumberJSON
    {
        [JsonProperty("date")]
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonProperty("ssn_predicted")]
        [JsonPropertyName("ssn_predicted")]
        public double? SsnPredicted { get; set; }

        [JsonProperty("ssn_high")]
        [JsonPropertyName("ssn_high")]
        public double? SsnHigh { get; set; }

        [JsonProperty("ssn_low")]
        [JsonPropertyName("ssn_low")]
        public double? SsnLow { get; set; }

        [JsonProperty("flux_predicted")]
        [JsonPropertyName("flux_predicted")]
        public double? FluxPredicted { get; set; }

        [JsonProperty("flux_high")]
        [JsonPropertyName("flux_high")]
        public double? FluxHigh { get; set; }

        [JsonProperty("flux_low")]
        [JsonPropertyName("flux_low")]
        public double? FluxLow { get; set; }
    }
}
