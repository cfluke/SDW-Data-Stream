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
    public class NOAASWPCSolarProbabilitiesJSON
    {
        [JsonProperty("date")]
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("c_class_1_day")]
        [JsonPropertyName("c_class_1_day")]
        public int? CClass1Day { get; set; }

        [JsonProperty("c_class_2_day")]
        [JsonPropertyName("c_class_2_day")]
        public int? CClass2Day { get; set; }

        [JsonProperty("c_class_3_day")]
        [JsonPropertyName("c_class_3_day")]
        public int? CClass3Day { get; set; }

        [JsonProperty("m_class_1_day")]
        [JsonPropertyName("m_class_1_day")]
        public int? MClass1Day { get; set; }

        [JsonProperty("m_class_2_day")]
        [JsonPropertyName("m_class_2_day")]
        public int? MClass2Day { get; set; }

        [JsonProperty("m_class_3_day")]
        [JsonPropertyName("m_class_3_day")]
        public int? MClass3Day { get; set; }

        [JsonProperty("x_class_1_day")]
        [JsonPropertyName("x_class_1_day")]
        public int? XClass1Day { get; set; }

        [JsonProperty("x_class_2_day")]
        [JsonPropertyName("x_class_2_day")]
        public int? XClass2Day { get; set; }

        [JsonProperty("x_class_3_day")]
        [JsonPropertyName("x_class_3_day")]
        public int? XClass3Day { get; set; }

        [JsonProperty("10mev_protons_1_day")]
        [JsonPropertyName("10mev_protons_1_day")]
        public int? _10mevProtons1Day { get; set; }

        [JsonProperty("10mev_protons_2_day")]
        [JsonPropertyName("10mev_protons_2_day")]
        public int? _10mevProtons2Day { get; set; }

        [JsonProperty("10mev_protons_3_day")]
        [JsonPropertyName("10mev_protons_3_day")]
        public int? _10mevProtons3Day { get; set; }

        [JsonProperty("polar_cap_absorption")]
        [JsonPropertyName("polar_cap_absorption")]
        public string PolarCapAbsorption { get; set; }
    }
}
