using Newtonsoft.Json;

namespace analytics_challenge.Models
{
    public class Asset
    {
        [JsonProperty("asset_class")]
        public string? AssetClass { get; set; }

        [JsonProperty("initial_allocation")]
        public float InitialAllocation { get; set; }

        [JsonProperty("asset_mgmt_fee")]
        public float AssetMgmtFee { get; set; } = 0.0015f;

        [JsonProperty("initial_load_fee")]
        public float InitialLoadFee { get; set; } = 0;
    }
}
