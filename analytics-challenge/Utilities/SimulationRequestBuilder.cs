﻿using analytics_challenge.Models;

namespace analytics_challenge.Utilities
{
    public class SimulationRequestBuilder
    {
        private readonly SimulationParametersRequest simulationParameters;

        public SimulationRequestBuilder(SimulationParametersRequest simulationParameters)
        {
            this.simulationParameters = simulationParameters;
        }

        public SimulationRequest BuildSimulationRequest()
        {
            SimulationRequest simulationRequest = new SimulationRequest
            {
                Portfolios = this.BuildPortfolio(),
                GoalPercentiles = new List<int> { 5, 50 },
                WealthReturns = new List<int> { 50 },
                Loans = new List<Loan>(),
                Scenarios = 1000,
                TotalQuarters = 156,
                ActiveQuarters = 185,
                Goals = new List<Goal>(),
                Contributions = new List<Contribution>(),
                Percentiles = new List<int> { 5, 50, 75 }
            };

            return simulationRequest;
        }

        private List<Portfolio> BuildPortfolio()
        {
            return new List<Portfolio>
            {
                new Portfolio
                {
                    Name = "test",
                    Assets = this.BuildAssets(),
                    RebalancingFrequency = 2,
                    CashAssetClassName = this.simulationParameters.ScenarioSpace,
                    PortfolioMgmtFee = 0,
                    Liquid = true,
                    CapitalGainTaxRate = 0.15f,
                    IncomeTaxRate = 0.15f,
                    MaxCreditFraction = 0.5f
                }
            };
        }

        private List<Asset> BuildAssets()
        {
            List<Asset> assets = new List<Asset>();

            if (this.simulationParameters.AssetClasses is not null)
            {
                foreach (KeyValuePair<string, int> assetClass in this.simulationParameters.AssetClasses)
                {
                    assets.Add(new Asset
                    {
                        AssetClass = assetClass.Key,
                        InitialAllocation = assetClass.Value,
                    });
                }
            }

            return assets;
        }
    }
}
