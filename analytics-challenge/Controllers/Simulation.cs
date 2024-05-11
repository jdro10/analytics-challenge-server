using analytics_challenge.Models;
using analytics_challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace analytics_challenge.Controllers
{
    [ApiController]
    public class Simulation : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ISimulation _simulation;

        public Simulation(IHttpClientService httpClientService, ISimulation simulation)
        {
            this._httpClientService = httpClientService;
            this._simulation = simulation;
        }

        [HttpPost("api/simulation")]
        public async Task<IActionResult> PerformSimulation([FromBody] SimulationParametersRequest simulationParameters)
        {
            try
            {
                string result = await this._simulation.BuildSimulationRequest(simulationParameters);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
