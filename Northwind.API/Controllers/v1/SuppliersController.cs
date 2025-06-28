using Microsoft.AspNetCore.Mvc;
using Northwind.Data.DTOs;
using Northwind.Data.Services;


namespace Northwind.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SuppliersController : ControllerBase
    {
        ISuppliersService _service;
        public SuppliersController(ISuppliersService suppliersService)
        {
            _service = suppliersService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var output = await _service.GetListAsync();
            return output == null ? NotFound() : Ok(output);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var output = await _service.GetByIdAsync(id);
            return output == null ? NotFound() : Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupplierDto input)
        {
            var output = await _service.SaveAsync(input);
            if (output.IsSuccess) return Ok(output.Message);
            return BadRequest(output.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] SupplierDto input)
        {
            var output = await _service.UpdateAsync(input);
            if (output.IsSuccess) return Ok(output.Message);
            return BadRequest(output.Message);
        }

    }
}
