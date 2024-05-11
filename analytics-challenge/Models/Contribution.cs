namespace analytics_challenge.Models
{
    public class Contribution
    {
        public string? Name { get; set; }
        public bool? Nominal { get; set; }
        public Dictionary<string, double>? Values { get; set; }
        public int? Portfolio { get; set; }
    }
}
