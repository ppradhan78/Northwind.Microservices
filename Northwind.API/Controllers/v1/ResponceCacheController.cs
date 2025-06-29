using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ResponceCacheController : ControllerBase
    {
        public ResponceCacheController() { }
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public async Task<IActionResult> Get()
        {
            return Ok(new { Id = 1, Name = "John Doe" });
        }
    }
}
