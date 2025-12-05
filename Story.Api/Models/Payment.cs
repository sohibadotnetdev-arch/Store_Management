namespace Store.Api.Models
{
    public class Payment
    {

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public long? SaleId { get; set; } 
        public Sale? Sale { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string? Note { get; set; }
    }
}
