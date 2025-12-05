using Microsoft.EntityFrameworkCore;
using Store.Api.Dal;
using Store.Api.Models;

namespace Store.Api.Repostories
{
    public class ProductRepository : IProductRepositoy
    {


        private readonly StoreDbContext _context;
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
               await _context.SaveChangesAsync();
        }

        public  async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
               await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public  async Task<Product?> GetByIdAsync(long id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
               await _context.SaveChangesAsync();
           
        }


       
       
    }
}

