using Microsoft.EntityFrameworkCore;
using Store.Api.Dal;
using Store.Api.Models;

namespace Store.Api.Repostories.PaymentsRepositories
{
    public class PaymentPepository : IPaymentPepository
    {
        private readonly StoreDbContext _context;
        public PaymentPepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public  async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payments
                .Include(p => p.Customer) 
                .ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(long id)
        {
            return await _context.Payments
                    .Include(p => p.Customer)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public  async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

      public async  Task<Payment?> DeleteAsync(long id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
            return payment;
        }
    }
}
