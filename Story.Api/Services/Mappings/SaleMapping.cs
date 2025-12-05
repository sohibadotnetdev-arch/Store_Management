using Store.Api.Dtos.SaleDTOs;
using Store.Api.Models;
using System.Linq;

namespace Store.Api.Services.Mappings
{
    public static class SaleMapping
    {
        public static Sale ToModel(SaleCreateDto dto)
        {
            return new Sale
            {
                SellerId = dto.SellerId,
                CustomerId = dto.CustomerId,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount,
                DebtAmount = dto.TotalAmount - dto.PaidAmount,
                PaymentMethod = dto.PaymentMethod,
                Note = dto.Note,
                Datetime = DateTime.UtcNow,
                Items = dto.Items.Select(SaleItemMapping.ToModel).ToList()
            };
        }

        // Model -> ReadDto
        public static SaleReadDto ToReadDto(Sale sale)
        {
            return new SaleReadDto
            {
                Id = sale.Id,
                SellerId = sale.SellerId,
                SellerName = sale.Seller.Name,
                CustomerId = sale.CustomerId,
                CustomerName = sale.Customer?.Name,
                TotalAmount = sale.TotalAmount,
                PaidAmount = sale.PaidAmount,
                DebtAmount = sale.DebtAmount,
                PaymentMethod = sale.PaymentMethod,
                Note = sale.Note,
                Datetime = sale.Datetime,
                Items = sale.Items.Select(SaleItemMapping.ToReadDto).ToList()
            };
        }

        // UpdateDto -> Model
        public static void UpdateModel(Sale sale, SaleUpdateDto dto)
        {
            sale.SellerId = dto.SellerId;
            sale.CustomerId = dto.CustomerId;
            sale.TotalAmount = dto.TotalAmount;
            sale.PaidAmount = dto.PaidAmount;
            sale.DebtAmount = dto.TotalAmount - dto.PaidAmount;
            sale.PaymentMethod = dto.PaymentMethod;
            sale.Note = dto.Note;

            // Itemsni update qilish: eski Itemsni tozalab, yangilarini qo'shamiz
            // Itemsni yangilash uchun avval eski Itemsni tozalaymiz
            sale.Items.Clear();

         
        }
    }

}

