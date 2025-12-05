using Store.Api.Models;

namespace Store.Api.Repostories
{
    public interface IProductRepositoy
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(long id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
