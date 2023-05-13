using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSADataStreams
{
    public class NOAASWPCEnlilTimeSeriesJSON
    {
        [JsonProperty("time_tag")]
        [JsonPropertyName("time_tag")]
        public DateTime? TimeTag { get; set; }

        [JsonProperty("earth_particles_per_cm3")]
        [JsonPropertyName("earth_particles_per_cm3")]
        public double? EarthParticlesPerCm3 { get; set; }

        [JsonProperty("temperature")]
        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        [JsonProperty("v_r")]
        [JsonPropertyName("v_r")]
        public double? VR { get; set; }

        [JsonProperty("v_theta")]
        [JsonPropertyName("v_theta")]
        public double? VTheta { get; set; }

        [JsonProperty("v_phi")]
        [JsonPropertyName("v_phi")]
        public double? VPhi { get; set; }

        [JsonProperty("b_r")]
        [JsonPropertyName("b_r")]
        public double? BR { get; set; }

        [JsonProperty("b_theta")]
        [JsonPropertyName("b_theta")]
        public double? BTheta { get; set; }

        [JsonProperty("b_phi")]
        [JsonPropertyName("b_phi")]
        public double? BPhi { get; set; }

        [JsonProperty("polarity")]
        [JsonPropertyName("polarity")]
        public double? Polarity { get; set; }

        [JsonProperty("cloud")]
        [JsonPropertyName("cloud")]
        public object Cloud { get; set; }
    }


}
