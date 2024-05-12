using analytics_challenge.Models;

namespace analytics_challenge.Services.Interfaces
{
    public interface ISimulation
    {
        Task<string> PerformSimulationRequest(SimulationRequest simulationRequest, string? scenarioSpace);

        Task<string> BuildSimulationRequest(SimulationParametersRequest simulationParametersRequest);
    }
}
