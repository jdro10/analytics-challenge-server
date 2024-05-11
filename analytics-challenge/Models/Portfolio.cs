using Newtonsoft.Json;

namespace analytics_challenge.Models
{
    public class Portfolio
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("assets")]
        public List<Asset>? Assets { get; set; }

        [JsonProperty("rebalancing_frequency")]
        public int RebalancingFrequency { get; set; }

        [JsonProperty("cash_asset_class_name")]
        public string? CashAssetClassName { get; set; }

        [JsonProperty("portfolio_mgmt_fee")]
        public float PortfolioMgmtFee { get; set; }

        [JsonProperty("liquid")]
        public bool Liquid { get; set; }

        [JsonProperty("capital_gain_tax_rate")]
        public float CapitalGainTaxRate { get; set; }

        [JsonProperty("income_tax_rate")]
        public float IncomeTaxRate { get; set; }

        [JsonProperty("max_credit_fraction")]
        public float MaxCreditFraction { get; set; }
    }
}
