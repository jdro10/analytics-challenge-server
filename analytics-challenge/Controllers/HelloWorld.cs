using Microsoft.AspNetCore.Mvc;

namespace analytics_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorld : ControllerBase
    {
        private readonly ILogger<HelloWorld> _logger;

        public HelloWorld(ILogger<HelloWorld> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetHelloWorld()
        {
            return "Hello World";
        }
    }
}
