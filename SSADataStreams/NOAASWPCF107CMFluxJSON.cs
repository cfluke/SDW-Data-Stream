using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCF107CMFluxJSON
    {
        [JsonProperty("time_tag")]
        [JsonPropertyName("time_tag")]
        public DateTime? TimeTag { get; set; }

        [JsonProperty("frequency")]
        [JsonPropertyName("frequency")]
        public int? Frequency { get; set; }

        [JsonProperty("flux")]
        [JsonPropertyName("flux")]
        public double? Flux { get; set; }

        [JsonProperty("reporting_schedule")]
        [JsonPropertyName("reporting_schedule")]
        public string ReportingSchedule { get; set; }

        [JsonProperty("avg_begin_date")]
        [JsonPropertyName("avg_begin_date")]
        public DateTime? AvgBeginDate { get; set; }

        [JsonProperty("ninety_day_mean")]
        [JsonPropertyName("ninety_day_mean")]
        public double? NinetyDayMean { get; set; }

        [JsonProperty("rec_count")]
        [JsonPropertyName("rec_count")]
        public int? RecCount { get; set; }
    }
}
