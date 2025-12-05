using Microsoft.EntityFrameworkCore;
using Store.Api.Dal;
using Store.Api.Models;

namespace Store.Api.Repostories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository

    {
        private readonly StoreDbContext _context;
        public CustomerRepository(StoreDbContext context)
        {
            _context = context;
        }
        public  async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public  async Task<Customer?> GetByIdAsync(long id)
        {
            return await _context.Customers
                .Include(c => c.Payments) 
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public  async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

       public async   Task<Customer?> DeleteAsync(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return customer;
        }
    }
}
