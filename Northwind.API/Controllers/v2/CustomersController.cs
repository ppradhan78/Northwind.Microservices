using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.API.Controllers.v2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { CustomerId = 1, FullName = "John Doe", Email = "john@example.com" });
        }
    }
}
