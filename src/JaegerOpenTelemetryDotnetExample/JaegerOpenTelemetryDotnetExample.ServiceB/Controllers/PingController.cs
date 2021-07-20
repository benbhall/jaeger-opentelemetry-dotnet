using Microsoft.AspNetCore.Mvc;
using OpenTelemetry;
using System.Diagnostics;

namespace JaegerOpenTelemetryDotnetExample.ServiceB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var infoFromContext = Baggage.Current.GetBaggage("ExampleItem");

            using var source = new ActivitySource("ExampleTracer");

            // A span
            using var activity = source.StartActivity("In Service B GET method");
            activity?.SetTag("InfoServiceBReceived", infoFromContext);
            return Ok();
        }
    }
}