using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCElectronFluenceForecastJSON
    {
        [JsonProperty("date")]
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonProperty("speed")]
        [JsonPropertyName("speed")]
        public double? Speed { get; set; }

        [JsonProperty("fluence")]
        [JsonPropertyName("fluence")]
        public object Fluence { get; set; }

        [JsonProperty("fluence_day_two")]
        [JsonPropertyName("fluence_day_two")]
        public double? FluenceDayTwo { get; set; }

        [JsonProperty("fluence_day_three")]
        [JsonPropertyName("fluence_day_three")]
        public double? FluenceDayThree { get; set; }

        [JsonProperty("fluence_day_four")]
        [JsonPropertyName("fluence_day_four")]
        public double? FluenceDayFour { get; set; }
    }
}
