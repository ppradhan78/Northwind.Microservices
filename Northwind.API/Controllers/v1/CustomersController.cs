using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CustomersController : ControllerBase
    {
       static int noOfTimeCalled = 0;

        public CustomersController() { }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine("########################################");
            Console.WriteLine("No. Of Time Called:" + noOfTimeCalled++);
            Console.WriteLine("########################################");
            //throw new Exception("new Exception");
            //500 Retry
            return StatusCode(500, "Custom internal server error");
            //Timeout Retry
            //await Task.Delay(5000); // Simulate long operation (5 seconds
            //No timeout
            //await Task.Delay(50);
            return Ok(new { Id = 1, Name = "John Doe" });
        }
    }
}
