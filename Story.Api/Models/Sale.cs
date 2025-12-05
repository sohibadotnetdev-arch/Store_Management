namespace Store.Api.Models
{
    public class Sale
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public User Seller { get; set; } = null!;
        public long? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DebtAmount { get; set; }
        public string PaymentMethod { get; set; } = null!; // cash, card, transfer
        public string? Note { get; set; }
        public DateTime Datetime { get; set; } = DateTime.UtcNow;

        public List<SaleItem> Items { get; set; } = new();

    }
}
