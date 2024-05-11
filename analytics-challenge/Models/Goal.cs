namespace analytics_challenge.Models
{
    public class Goal
    {
        public string? Name { get; set; }
        public bool Nominal { get; set; }
        public string? Kind { get; set; }
        public float? ReturnGoal { get; set; }
        public int? StartQuarter { get; set; }
        public int? EndQuarter { get; set; }
        public int? Periodicity { get; set; }
        public Dictionary<string, float>? Values { get; set; }
        public List<int>? Portfolios { get; set; }
    }
}
