namespace Store.Api.Models
{
    public class SaleItem
    {
        public long Id { get; set; }
        public long SaleId { get; set; }
        public Sale Sale { get; set; } = null!;

        public long ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
