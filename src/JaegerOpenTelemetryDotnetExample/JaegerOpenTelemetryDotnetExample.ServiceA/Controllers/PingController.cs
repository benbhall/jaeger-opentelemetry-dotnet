using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JaegerOpenTelemetryDotnetExample.ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            var serviceResponse = new StringBuilder();
            serviceResponse.AppendLine("Service A: OK");

            try
            {
                using var client = new HttpClient();
                var result = await client.GetAsync("https://localhost:6001/ping");
                serviceResponse.AppendLine(await result.Content.ReadAsStringAsync());

            }
            catch (HttpRequestException)
            {
                serviceResponse.AppendLine("Service B: Check it is running, then reload this page");
                return serviceResponse.ToString();
            }

            return serviceResponse.ToString();
        }
    }
}