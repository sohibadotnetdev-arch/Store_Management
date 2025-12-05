using Microsoft.AspNetCore.Mvc;
using Store.Api.Dtos.PaymentDTOs;
using Store.Api.Services.PaymentServices;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentReadDto>>> GetAll()
        {
            var payments = await _service.GetAllAsync();
            return Ok(payments);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<List<PaymentReadDto>>> GetByCustomer(long customerId)
        {
            var payments = await _service.GetByCustomerAsync(customerId);
            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentReadDto>> Create(PaymentCreateDto dto)
        {
            var payment = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByCustomer), new { customerId = payment.CustomerId }, payment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentReadDto>> Update(long id, PaymentUpdatedDto dto)
        {
            var payment = await _service.UpdateAsync(id, dto);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentReadDto>> Delete(long id)
        {
            var payment = await _service.DeleteAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment); 
        }
    }
}
