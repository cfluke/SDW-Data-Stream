using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class NOAASWPCSolarRegionsJSON
    {
        [JsonProperty("observed_date")]
        [JsonPropertyName("observed_date")]
        public string ObservedDate { get; set; }

        [JsonProperty("region")]
        [JsonPropertyName("region")]
        public int? Region { get; set; }

        [JsonProperty("latitude")]
        [JsonPropertyName("latitude")]
        public int? Latitude { get; set; }

        [JsonProperty("longitude")]
        [JsonPropertyName("longitude")]
        public int? Longitude { get; set; }

        [JsonProperty("location")]
        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonProperty("carrington_longitude")]
        [JsonPropertyName("carrington_longitude")]
        public int? CarringtonLongitude { get; set; }

        [JsonProperty("old_carrington_longitude")]
        [JsonPropertyName("old_carrington_longitude")]
        public int? OldCarringtonLongitude { get; set; }

        [JsonProperty("area")]
        [JsonPropertyName("area")]
        public int? Area { get; set; }

        [JsonProperty("spot_class")]
        [JsonPropertyName("spot_class")]
        public string SpotClass { get; set; }

        [JsonProperty("extent")]
        [JsonPropertyName("extent")]
        public int? Extent { get; set; }

        [JsonProperty("number_spots")]
        [JsonPropertyName("number_spots")]
        public int? NumberSpots { get; set; }

        [JsonProperty("mag_class")]
        [JsonPropertyName("mag_class")]
        public string MagClass { get; set; }

        [JsonProperty("mag_string")]
        [JsonPropertyName("mag_string")]
        public object MagString { get; set; }

        [JsonProperty("status")]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonProperty("c_xray_events")]
        [JsonPropertyName("c_xray_events")]
        public int? CXrayEvents { get; set; }

        [JsonProperty("m_xray_events")]
        [JsonPropertyName("m_xray_events")]
        public int? MXrayEvents { get; set; }

        [JsonProperty("x_xray_events")]
        [JsonPropertyName("x_xray_events")]
        public int? XXrayEvents { get; set; }

        [JsonProperty("proton_events")]
        [JsonPropertyName("proton_events")]
        public object ProtonEvents { get; set; }

        [JsonProperty("s_flares")]
        [JsonPropertyName("s_flares")]
        public int? SFlares { get; set; }

        [JsonProperty("impulse_flares_1")]
        [JsonPropertyName("impulse_flares_1")]
        public int? ImpulseFlares1 { get; set; }

        [JsonProperty("impulse_flares_2")]
        [JsonPropertyName("impulse_flares_2")]
        public int? ImpulseFlares2 { get; set; }

        [JsonProperty("impulse_flares_3")]
        [JsonPropertyName("impulse_flares_3")]
        public int? ImpulseFlares3 { get; set; }

        [JsonProperty("impulse_flares_4")]
        [JsonPropertyName("impulse_flares_4")]
        public int? ImpulseFlares4 { get; set; }

        [JsonProperty("protons")]
        [JsonPropertyName("protons")]
        public int? Protons { get; set; }

        [JsonProperty("c_flare_probability")]
        [JsonPropertyName("c_flare_probability")]
        public int? CFlareProbability { get; set; }

        [JsonProperty("m_flare_probability")]
        [JsonPropertyName("m_flare_probability")]
        public int? MFlareProbability { get; set; }

        [JsonProperty("x_flare_probability")]
        [JsonPropertyName("x_flare_probability")]
        public int? XFlareProbability { get; set; }

        [JsonProperty("proton_probability")]
        [JsonPropertyName("proton_probability")]
        public int? ProtonProbability { get; set; }

        [JsonProperty("first_date")]
        [JsonPropertyName("first_date")]
        public DateTime? FirstDate { get; set; }
    }
}
