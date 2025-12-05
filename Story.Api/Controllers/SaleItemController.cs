using Microsoft.AspNetCore.Mvc;
using Store.Api.Dtos.SaleItemDTOs;
using Store.Api.Services;
using Store.Api.Services.SaleItemServices;

namespace Store.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleItemController : ControllerBase
    {
        private readonly SaleItemService _service;

        public SaleItemController(SaleItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleItemCreateDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

   
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] SaleItemUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
