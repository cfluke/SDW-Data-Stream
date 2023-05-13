using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCEditedEventsJSON
    {
        [JsonProperty("begin_datetime")]
        [JsonPropertyName("begin_datetime")]
        public DateTime? BeginDatetime { get; set; }

        [JsonProperty("begin_quality")]
        [JsonPropertyName("begin_quality")]
        public string BeginQuality { get; set; }

        [JsonProperty("max_datetime")]
        [JsonPropertyName("max_datetime")]
        public DateTime? MaxDatetime { get; set; }

        [JsonProperty("max_quality")]
        [JsonPropertyName("max_quality")]
        public string MaxQuality { get; set; }

        [JsonProperty("end_datetime")]
        [JsonPropertyName("end_datetime")]
        public DateTime? EndDatetime { get; set; }

        [JsonProperty("end_quality")]
        [JsonPropertyName("end_quality")]
        public string EndQuality { get; set; }

        [JsonProperty("observatory")]
        [JsonPropertyName("observatory")]
        public string Observatory { get; set; }

        [JsonProperty("quality")]
        [JsonPropertyName("quality")]
        public string Quality { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("coded_type")]
        [JsonPropertyName("coded_type")]
        public int? CodedType { get; set; }

        [JsonProperty("obsid")]
        [JsonPropertyName("obsid")]
        public int? Obsid { get; set; }

        [JsonProperty("location")]
        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonProperty("frequency")]
        [JsonPropertyName("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("particulars1")]
        [JsonPropertyName("particulars1")]
        public string Particulars1 { get; set; }

        [JsonProperty("particulars2")]
        [JsonPropertyName("particulars2")]
        public string Particulars2 { get; set; }

        [JsonProperty("particulars3")]
        [JsonPropertyName("particulars3")]
        public string Particulars3 { get; set; }

        [JsonProperty("particulars4")]
        [JsonPropertyName("particulars4")]
        public string Particulars4 { get; set; }

        [JsonProperty("particulars5")]
        [JsonPropertyName("particulars5")]
        public object Particulars5 { get; set; }

        [JsonProperty("particulars6")]
        [JsonPropertyName("particulars6")]
        public object Particulars6 { get; set; }

        [JsonProperty("particulars7")]
        [JsonPropertyName("particulars7")]
        public object Particulars7 { get; set; }

        [JsonProperty("particulars8")]
        [JsonPropertyName("particulars8")]
        public object Particulars8 { get; set; }

        [JsonProperty("particulars9")]
        [JsonPropertyName("particulars9")]
        public object Particulars9 { get; set; }

        [JsonProperty("particulars10")]
        [JsonPropertyName("particulars10")]
        public string Particulars10 { get; set; }

        [JsonProperty("region")]
        [JsonPropertyName("region")]
        public int? Region { get; set; }

        [JsonProperty("bin")]
        [JsonPropertyName("bin")]
        public int? Bin { get; set; }

        [JsonProperty("age")]
        [JsonPropertyName("age")]
        public object Age { get; set; }

        [JsonProperty("status_code")]
        [JsonPropertyName("status_code")]
        public int? StatusCode { get; set; }

        [JsonProperty("status_text")]
        [JsonPropertyName("status_text")]
        public string StatusText { get; set; }

        [JsonProperty("change_flag")]
        [JsonPropertyName("change_flag")]
        public int? ChangeFlag { get; set; }
    }
}
