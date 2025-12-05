namespace Store.Api.Dtos.SaleItemDTOs
{
    public class SaleItemReadDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
