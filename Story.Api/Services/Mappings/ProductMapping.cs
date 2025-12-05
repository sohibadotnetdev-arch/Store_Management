using Store.Api.Dtos.ProductDTOs;
using Store.Api.Models;

namespace Store.Api.Services.Mappings
{
    public static class ProductMapping
    {
        // CreateDto -> Model
        public static Product ToModel(this ProductCreateDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                SKU = dto.SKU,
                CategoryId = dto.CategoryId,
                BuyPrice = (decimal)dto.BuyPrice,
                SellPrice = (decimal)dto.SellPrice,
                StockQuantity = dto.StockQuantity,
                Unit = dto.Unit,
                Barcode = dto.Barcode
            };
        }

        // Model -> ReadDto
        public static ProductReadDto ToReadDto(this Product product)
        {
            return new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                SKU = product.SKU,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name ?? "",
                BuyPrice = (double)product.BuyPrice,
                SellPrice = (double)product.SellPrice,
                StockQuantity = product.StockQuantity,
                Unit = product.Unit,
                Barcode = product.Barcode
            };
        }

        // UpdateDto -> Model (update)
        public static void UpdateDto(this Product product, ProductUpdateDto dto)
        {
            product.Name = dto.Name;
            product.SKU = dto.SKU;
            product.CategoryId = dto.CategoryId;
            product.BuyPrice = (decimal)dto.BuyPrice;
            product.SellPrice = (decimal)dto.SellPrice;
            product.StockQuantity = dto.StockQuantity;
            product.Unit = dto.Unit;
            product.Barcode = dto.Barcode;
        }
    }
}
