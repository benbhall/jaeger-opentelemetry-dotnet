using Microsoft.AspNetCore.Mvc;

namespace JaegerOpenTelemetryDotnetExample.ServiceB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("Service B: OK");
        }
    }
}
