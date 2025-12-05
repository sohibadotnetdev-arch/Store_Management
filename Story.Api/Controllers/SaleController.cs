using Microsoft.AspNetCore.Mvc;
using Store.Api.Dtos.SaleDTOs;
using Store.Api.Services.SaleServices;

namespace Store.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var sale = await _service.GetByIdAsync(id);
            return sale == null ? NotFound() : Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaleCreateDto dto)
        {
            var sale = await _service.CreateAsync(dto);
            return Ok(sale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, SaleUpdateDto dto)
        {
            var sale = await _service.UpdateAsync(id, dto);
            return sale == null ? NotFound() : Ok(sale);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var sale = await _service.DeleteAsync(id);
            return sale == null ? NotFound() : Ok(sale);
        }
    }
}
