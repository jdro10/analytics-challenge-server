using analytics_challenge.Models;
using analytics_challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace analytics_challenge.Controllers
{
    [ApiController]
    public class Simulation : Controller
    {
        private readonly ISimulation _simulation;

        public Simulation(ISimulation simulation)
        {
            this._simulation = simulation;
        }

        /// <summary>
        /// Endpoint builds the request given a specific asset classes and scenario space
        /// then calls the API simulation endpoint and returns the result
        /// </summary>
        /// <param name="simulationParameters"></param>
        [HttpPost("api/simulation")]
        public async Task<IActionResult> PerformSimulation([FromBody] SimulationParametersRequest simulationParameters)
        {
            try
            {
                return Ok(await this._simulation.BuildSimulationRequest(simulationParameters));
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
