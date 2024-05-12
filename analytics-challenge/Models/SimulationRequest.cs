using Newtonsoft.Json;

namespace analytics_challenge.Models
{
    public class SimulationRequest
    {
        [JsonProperty("portfolios")]
        public List<Portfolio>? Portfolios { get; set; }

        [JsonProperty("goal_percentiles")]
        public List<int>? GoalPercentiles { get; set; }

        [JsonProperty("wealth_returns")]
        public List<int>? WealthReturns { get; set; }

        [JsonProperty("loans")]
        public List<Loan>? Loans { get; set; }

        [JsonProperty("request_id")]
        public string? RequestId { get; set; }

        [JsonProperty("scenarios")]
        public int Scenarios { get; set; }

        [JsonProperty("total_quarters")]
        public int TotalQuarters { get; set; }

        [JsonProperty("active_quarters")]
        public int ActiveQuarters { get; set; }

        [JsonProperty("goals")]
        public List<Goal>? Goals { get; set; }

        [JsonProperty("contributions")]
        public List<Contribution>? Contributions { get; set; }

        [JsonProperty("percentiles")]
        public List<int>? Percentiles { get; set; }
    }
}
