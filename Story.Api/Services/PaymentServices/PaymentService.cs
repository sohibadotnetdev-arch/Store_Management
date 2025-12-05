using Store.Api.Dtos.PaymentDTOs;
using Store.Api.Repostories.PaymentsRepositories;
using Store.Api.Services.Mappings;

namespace Store.Api.Services.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentPepository _repo;
        public PaymentService(IPaymentPepository repository)
        {
            _repo = repository;
        }

        public async Task<List<PaymentReadDto>> GetAllAsync()
        {
            var payments = await _repo.GetAllAsync();
            return payments.Select(PaymentMapping.ToReadDto).ToList();
        }

        public async Task<List<PaymentReadDto>> GetByCustomerAsync(long customerId)
        {
            var payments = await _repo.GetAllAsync();
            return payments
                .Where(p => p.CustomerId == customerId)
                .Select(PaymentMapping.ToReadDto)
                .ToList();
        }

        public async Task<PaymentReadDto> AddAsync(PaymentCreateDto dto)
        {
            var payment = PaymentMapping.ToModel(dto);

            await _repo.AddAsync(payment);

            var customer = payment.Customer;
            if (customer != null)
            {
                customer.TotalDebt -= payment.Amount;
                await _repo.UpdateAsync(payment);
            }

            return PaymentMapping.ToReadDto(payment);
        }

        public async Task<PaymentReadDto?> UpdateAsync(long id, PaymentUpdatedDto dto)
        {
            var payment = await _repo.GetByIdAsync(id);
            if (payment == null) return null;

            PaymentMapping.UpdateModel(payment, dto);
            await _repo.UpdateAsync(payment);

            return PaymentMapping.ToReadDto(payment);
        }

       public async   Task<PaymentReadDto?> DeleteAsync(long id)
        {
            var payment = await _repo.DeleteAsync(id);
            return payment == null ? null : PaymentMapping.ToReadDto(payment);
        }
    }
}
