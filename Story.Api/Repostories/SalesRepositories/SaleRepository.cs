using Microsoft.EntityFrameworkCore;
using Store.Api.Dal;
using Store.Api.Models;
using Store.Api.Repostories.SaleItemsRepositories;
using Store.Api.Repostories.SelesRepositories;

namespace Store.Api.Repostories.SalesRepositories
{
    public class SaleRepository:ISaleRepository
    {
        private readonly StoreDbContext _context;

        public SaleRepository(StoreDbContext context)
        {
            _context = context;
        }

        public  async Task AddAsync(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }

        public  async Task<List<Sale>> GetAllAsync()
        {
            return await _context.Sales
               .Include(s => s.Items)
                   .ThenInclude(i => i.Product)
               .Include(s => s.Customer)
               .Include(s => s.Seller)
               .ToListAsync();
        }

        public async Task<Sale?> GetByIdAsync(long id)
        {
            return await _context.Sales
               .Include(s => s.Items)
                   .ThenInclude(i => i.Product)
               .Include(s => s.Customer)
               .Include(s => s.Seller)
               .FirstOrDefaultAsync(s => s.Id == id);
        }

        public  async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }
    }
}
