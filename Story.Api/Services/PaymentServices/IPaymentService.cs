using Store.Api.Dtos.PaymentDTOs;
using Store.Api.Models;

namespace Store.Api.Services.PaymentServices
{
    public interface  IPaymentService
    {
        Task<List<PaymentReadDto>> GetAllAsync();
        Task<List<PaymentReadDto>> GetByCustomerAsync(long customerId);
        Task<PaymentReadDto> AddAsync(PaymentCreateDto dto);
        Task<PaymentReadDto?> UpdateAsync(long id, PaymentUpdatedDto dto);
        Task<PaymentReadDto?> DeleteAsync(long id);
    }
}
