using Store.Api.Dtos.SaleItemDTOs;

namespace Store.Api.Dtos.SaleDTOs
{
    public class SaleCreateDto
    {
        public long SellerId { get; set; }
        public long? CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string? Note { get; set; }

        public List<SaleItemCreateDto> Items { get; set; } = new();
    }
}
