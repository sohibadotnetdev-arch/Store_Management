using Microsoft.EntityFrameworkCore;
using Store.Api.Dal;
using Store.Api.Models;
using Store.Api.Repostories.SaleItemsRepositories;
using Store.Api.Repostories.SalesRepositories;

namespace Store.Api.Repostories.SalesRepositories
{
    public class SaleItemsRepository : ISaleItemsRepository

    {
        private readonly StoreDbContext _context;
        public SaleItemsRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SaleItem item)
        {
            _context.SaleItem.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var item = await _context.SaleItem.FindAsync(id);
            if (item != null)
            {
                _context.SaleItem.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SaleItem>> GetAllAsync()
        {
            return await _context.SaleItem
                .Include(si => si.Product)
                .Include(si => si.Sale)
                .ToListAsync();
        }

        public  async Task<SaleItem?> GetByIdAsync(long id)
        {
            return await _context.SaleItem
                .Include(si => si.Product)
                .Include(si => si.Sale)
                .FirstOrDefaultAsync(si => si.Id == id);
        }

        public async Task UpdateAsync(SaleItem item)
        {
            _context.SaleItem.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
