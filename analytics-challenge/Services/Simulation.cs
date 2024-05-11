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

        public async Task<string> BuildSimulationRequest(SimulationParametersRequest simulationParameters)
        {
            SimulationRequest simulationRequest = new SimulationRequestBuilder(simulationParameters).BuildSimulationRequest();

            return await this.PerformSimulationRequest(simulationRequest);
        }

        public async Task<string> PerformSimulationRequest(SimulationRequest simulationRequest)
        {
            return await this._httpClientService.PostAsync("simulations", simulationRequest);
        }
    }
}
