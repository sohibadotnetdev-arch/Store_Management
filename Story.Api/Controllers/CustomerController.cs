using Microsoft.AspNetCore.Mvc;
using Store.Api.Dtos.CustomerDto;
using Store.Api.Services.CustomServices;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomService _service;

        public CustomerController(CustomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerReadDto>>> GetAll()
        {
            var customers = await _service.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDto>> Get(long id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> Create(CustomerCreateDto dto)
        {
            var customer = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerReadDto>> Update(long id, CustomerUpdateDto dto)
        {
            var customer = await _service.UpdateAsync(id, dto);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerReadDto>> Delete(long id)
        {
            var customer = await _service.DeleteAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer); 
        }
    }
}
