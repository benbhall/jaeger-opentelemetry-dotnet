//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace JaegerOpenTelemetryDotnetExample.ServiceA.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class PingController : ControllerBase
//    {


//        [HttpGet]
//        public async Task<string> Get()
//        {
//            using var source = new ActivitySource("ExampleSpan");

//            var serviceResponse = new StringBuilder();
//            serviceResponse.AppendLine("Service A: OK");

//            try
//            {
//                using var activity = source.StartActivity("Call to Service B");

//                using var client = new HttpClient();
//                var result = await client.GetAsync("http://aspcore-service-b:6001/ping");
//                var responseContent = await result.Content.ReadAsStringAsync();
//                serviceResponse.AppendLine(responseContent);

//                using var activityTwo = source.StartActivity("Arbitrary 100ms delay");
//                await Task.Delay(10);
//            }
//            catch (HttpRequestException)
//            {
//                serviceResponse.AppendLine("Service B: Check it is running, then reload this page");
//                return serviceResponse.ToString();
//            }

//            return serviceResponse.ToString();
//        }
//    }
//}



using Microsoft.AspNetCore.Mvc;
using OpenTelemetry;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace JaegerOpenTelemetryDotnetExample.ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var source = new ActivitySource("ExampleTracer");

            // A span
            using var activity = source.StartActivity("Call to Service B");

            Baggage.Current.SetBaggage("ExampleItem", "The information");

            // 'Ping' Service B
            using var client = new HttpClient();
            _ = await client.GetAsync("http://aspcore-service-b:6001/ping");

            // Another span
            using var activityTwo = source.StartActivity("Arbitrary 10ms delay");
            await Task.Delay(10);

            return Ok();
        }
    }
}