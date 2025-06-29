using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;

namespace Northwind.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RetryPolicyController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        int callTime = 0;
        public RetryPolicyController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = _clientFactory.CreateClient("NorthwindClient");
            var response = await client.GetAsync("Customers");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }

            return StatusCode((int)response.StatusCode);
        }
    }
}
