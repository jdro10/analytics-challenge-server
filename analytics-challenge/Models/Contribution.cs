using Newtonsoft.Json;

namespace analytics_challenge.Models
{
    public class Contribution
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("nominal")]
        public bool? Nominal { get; set; }

        [JsonProperty("values")]
        public Dictionary<string, double>? Values { get; set; }

        [JsonProperty("portfolio")]
        public int? Portfolio { get; set; }
    }
}
