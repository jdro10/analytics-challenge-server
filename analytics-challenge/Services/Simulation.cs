using analytics_challenge.Models;
using analytics_challenge.Services.Interfaces;
using analytics_challenge.Utilities;

namespace analytics_challenge.Services
{
    public class Simulation : ISimulation
    {
        private readonly IHttpClientService _httpClientService;

        public Simulation(IHttpClientService httpClientService)
        {
            this._httpClientService = httpClientService;
        }

        /// <summary>
        /// Builds the request needed for the simulation API endpoint
        /// </summary>
        /// <param name="simulationParameters"></param>
        /// <returns></returns>
        public async Task<string> BuildSimulationRequest(SimulationParametersRequest simulationParameters)
        {
            SimulationRequest simulationRequest = new SimulationRequestBuilder(simulationParameters).BuildSimulationRequest();

            return await this.PerformSimulationRequest(simulationRequest);
        }

        /// <summary>
        /// Calls the HTTP client to perform a POST request using the built simulation request
        /// </summary>
        /// <param name="simulationRequest">The built simulation request</param>
        public async Task<string> PerformSimulationRequest(SimulationRequest simulationRequest)
        {
            return await this._httpClientService.PostAsync("simulations", simulationRequest);
        }
    }
}
