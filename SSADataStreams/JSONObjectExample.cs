using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace SSADataStreams
{
    public record class JSONObjectExample(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("html_url")] Uri GitHubHomeUrl,
        [property: JsonPropertyName("homepage")] Uri Homepage,
        [property: JsonPropertyName("watchers")] int Watchers,
        [property: JsonPropertyName("pushed_at")] DateTime LastPushUtc)
    {
        public DateTime LastPush => LastPushUtc.ToLocalTime();
    }
}
