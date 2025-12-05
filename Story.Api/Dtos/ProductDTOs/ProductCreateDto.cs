namespace Store.Api.Dtos.ProductDTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public long CategoryId { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Unit { get; set; }
        public string? Barcode { get; set; }

    }
}
