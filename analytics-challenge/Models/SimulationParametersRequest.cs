namespace analytics_challenge.Models
{
    public class SimulationParametersRequest
    {
        public string? ScenarioSpace { get; set; }
        public Dictionary<string, int>? AssetClasses { get; set; }
    }
}
