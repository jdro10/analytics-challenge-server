namespace analytics_challenge.Models
{
    public class SimulationParametersRequest
    {
        public string? ScenarioSpaceName { set; get; }
        public string? ScenarioSpace { get; set; }
        public Dictionary<string, int>? AssetClasses { get; set; }
    }
}
