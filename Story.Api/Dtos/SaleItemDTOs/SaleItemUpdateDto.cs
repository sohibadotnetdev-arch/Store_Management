namespace Store.Api.Dtos.SaleItemDTOs
{
    public class SaleItemUpdateDto
    {
        public long ProductId { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
