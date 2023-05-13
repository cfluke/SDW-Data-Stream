using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCPredictedF107CMFluxJSON
    {
        [JsonProperty("date")]
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonProperty("tencmfcst_1_day")]
        [JsonPropertyName("tencmfcst_1_day")]
        public int? Tencmfcst1Day { get; set; }

        [JsonProperty("tencmfcst_2_day")]
        [JsonPropertyName("tencmfcst_2_day")]
        public int? Tencmfcst2Day { get; set; }

        [JsonProperty("tencmfcst_3_day")]
        [JsonPropertyName("tencmfcst_3_day")]
        public int? Tencmfcst3Day { get; set; }
    }
}
