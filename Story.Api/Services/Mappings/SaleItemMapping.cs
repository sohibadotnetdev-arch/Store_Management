using Store.Api.Dtos.SaleItemDTOs;
using Store.Api.Models;

namespace Store.Api.Services.Mappings
{
    public static class SaleItemMapping
    {
        // CreateDto -> Model
        public static SaleItem ToModel(SaleItemCreateDto dto)
        {
            return new SaleItem
            {
                ProductId = dto.ProductId,
                Qty = dto.Qty,
                UnitPrice = dto.UnitPrice,
                TotalPrice = dto.UnitPrice * dto.Qty
            };
        }

        // UpdateDto -> Model
        public static void UpdateModel(SaleItem item, SaleItemUpdateDto dto)
        {
            item.ProductId = dto.ProductId;
            item.Qty = dto.Qty;
            item.UnitPrice = dto.UnitPrice;
            item.TotalPrice = dto.UnitPrice * dto.Qty;
        }

        // Model -> ReadDto
        public static SaleItemReadDto ToReadDto(SaleItem item)
        {
            return new SaleItemReadDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                Qty = item.Qty,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.TotalPrice
            };
        }
    }
}

