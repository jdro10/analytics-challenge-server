using analytics_challenge.Models;
using analytics_challenge.Utilities;

namespace analytics_challenge_tests
{
    public class Tests
    {
        private SimulationRequestBuilder builder;
        private SimulationParametersRequest simulationParameters;

        [SetUp]
        public void Setup()
        {
            this.simulationParameters = new SimulationParametersRequest
            {
                ScenarioSpace = "default_2c",
                ScenarioSpaceName = "CS_CHF",
                AssetClasses = new Dictionary<string, int>
                {
                    { "EQ_W", 10000 },
                    { "GOV_EM", 10000 }
                }
            };

            builder = new SimulationRequestBuilder(this.simulationParameters);
        }

        /// <summary>
        /// Test to ensure the proper construction of a simulation request.
        /// </summary>
        [Test]
        public void BuildSimulationRequest()
        {
            SimulationRequest simulationRequest = builder.BuildSimulationRequest();

            Assert.IsNotNull(simulationRequest);
        }

        /// <summary>
        /// Test to confirm the default setting of the cash asset value as CS_EUR when not specified.
        /// </summary>
        [Test]
        public void BuildSimulationRequestWithoutScenarioSpace()
        {
            this.simulationParameters = new SimulationParametersRequest
            {
                ScenarioSpace = "",
                ScenarioSpaceName = "",
                AssetClasses = new Dictionary<string, int>
                {
                    { "EQ_W", 10000 },
                    { "GOV_EM", 10000 }
                }
            };

            SimulationRequest simulationRequest = new SimulationRequestBuilder(this.simulationParameters).BuildSimulationRequest();

            Assert.IsTrue(simulationRequest.Portfolios?.FirstOrDefault()?.CashAssetClassName?.Equals("CS_EUR"));
        }

        /// <summary>
        /// Test to verify that the cash asset is appropriately assigned based on the provided scenario space.
        /// </summary>
        [Test]
        public void BuildSimulationRequestWithScenarioSpace()
        {
            SimulationRequest simulationRequest = builder.BuildSimulationRequest();

            Assert.IsTrue(simulationRequest.Portfolios?.FirstOrDefault()?.CashAssetClassName?.Equals("CS_CHF"));
        }

        /// <summary>
        /// Verify successful creation of assets classes based on the simulation request parameters.
        /// </summary>
        [Test]
        public void VerifyAssetClassesProperties()
        {
            SimulationRequest simulationRequest = builder.BuildSimulationRequest();

            var assetClass = simulationRequest.Portfolios?.FirstOrDefault()?.Assets?.FirstOrDefault();

            Assert.That(assetClass?.AssetClass, Is.EqualTo("EQ_W"));
            Assert.That(assetClass?.InitialAllocation, Is.EqualTo(10000));
        }

        /// <summary>
        /// Builds a simulation request and verifies the count of asset classes in the resulting request.
        /// </summary>
        [Test]
        public void VerifyAssetClassesCountInSimulationRequest()
        {
            SimulationRequest simulationRequest = builder.BuildSimulationRequest();

            Assert.That(simulationRequest.Portfolios?.FirstOrDefault()?.Assets?.Count, Is.EqualTo(2));
        }
    }
}