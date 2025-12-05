namespace Store.Api.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
       
        public decimal TotalDebt { get; set; } = 0;

       
        public List<Sale> Sales { get; set; } = new();

      
        public List<Payment> Payments { get; set; } = new();
    }
}
