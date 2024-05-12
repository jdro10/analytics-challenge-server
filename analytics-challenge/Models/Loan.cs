using Newtonsoft.Json;

namespace analytics_challenge.Models
{
    public class Loan
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("amount")]
        public float Amount { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("rate")]
        public float Rate { get; set; }

        [JsonProperty("spread")]
        public float Spread { get; set; }

        [JsonProperty("payment")]
        public float Payment {  get; set; }

        [JsonProperty("collateral_portfolios")]
        public List<int>? CollateralPortefolios {  get; set; }

        [JsonProperty("interest_portfolios")]
        public List<int>? InterestPortefolios { get; set; }

        [JsonProperty("amortization_portfolios")]
        public List<int>? AmortizationPortfolios { get; set; }

        [JsonProperty("amortization_schedule")]
        public string? AmortizationSchedule { get; set; }

        [JsonProperty("fixed_interest_duration")]
        public int FixedInterestDuration { get; set; }
    }
}
