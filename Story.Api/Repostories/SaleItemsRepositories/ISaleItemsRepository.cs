using Store.Api.Models;

namespace Store.Api.Repostories.SaleItemsRepositories
{
    public interface ISaleItemsRepository
    {
        Task<List<SaleItem>> GetAllAsync();
        Task<SaleItem?> GetByIdAsync(long id);
        Task AddAsync(SaleItem item);
        Task UpdateAsync(SaleItem item);
        Task DeleteAsync(long id);
    }
}
