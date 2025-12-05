using Store.Api.Dtos.SaleItemDTOs;

namespace Store.Api.Dtos.SaleDTOs
{
    public class SaleReadDto
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public string SellerName { get; set; } = null!;
        public long? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DebtAmount { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string? Note { get; set; }
        public DateTime Datetime { get; set; }

        public List<SaleItemReadDto> Items { get; set; } = new();
    }
}
