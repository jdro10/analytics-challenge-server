namespace analytics_challenge.Models
{
    public class Loan
    {
        public string? Name { get; set; }
        public float Amount { get; set; }
        public int Duration { get; set; }
        public float Rate { get; set; }
        public float Spread { get; set; }
        public float Payment {  get; set; }
        public List<int>? CollateralPortefolios {  get; set; }
        public List<int>? InterestPortefolios { get; set; }
        public List<int>? AmortizationPortfolios { get; set; }
        public string? AmortizationSchedule { get; set; }
        public int FixedInterestDuration { get; set; }
    }
}
