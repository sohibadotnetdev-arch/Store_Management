using Store.Api.Models;

namespace Store.Api.Repostories.PaymentsRepositories
{
    public interface IPaymentPepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(long id);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task<Payment?> DeleteAsync(long id);
    }
}
