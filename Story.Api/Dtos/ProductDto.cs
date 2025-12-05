using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Store.Api.Dtos
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public  long CategoryId {  get; set; }
        public long CategoryName {  get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Unit { get; set; } = null;
        public string? Barcode { get; set; } = null;
        
    }
}
