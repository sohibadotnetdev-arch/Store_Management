using Store.Api.Models;

namespace Store.Api.Repostories.CustomerRepositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(long id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task<Customer?> DeleteAsync(long id);
    }
}
