using Newtonsoft.Json;

namespace analytics_challenge.Models
{
    public class Goal
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("nominal")]
        public bool Nominal { get; set; }

        [JsonProperty("kind")]
        public string? Kind { get; set; }

        [JsonProperty("return_goal")]
        public float? ReturnGoal { get; set; }

        [JsonProperty("start_quarter")]
        public int? StartQuarter { get; set; }

        [JsonProperty("end_quarter")]
        public int? EndQuarter { get; set; }

        [JsonProperty("periodicity")]
        public int? Periodicity { get; set; }

        [JsonProperty("values")]
        public Dictionary<string, float>? Values { get; set; }

        [JsonProperty("portfolios")]
        public List<int>? Portfolios { get; set; }
    }
}
