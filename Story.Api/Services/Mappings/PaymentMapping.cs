using Store.Api.Dtos.PaymentDTOs;
using Store.Api.Models;

namespace Store.Api.Services.Mappings
{
    public static class PaymentMapping
    {
        public static Payment ToModel(PaymentCreateDto dto)
        {
            return new Payment
            {
                CustomerId = dto.CustomerId,
                Amount = dto.Amount,
                Note = dto.Note,
           
            };
        }

        public static PaymentReadDto ToReadDto(Payment payment)
        {
            return new PaymentReadDto
            {
                Id = payment.Id,
                CustomerId = payment.CustomerId,
                SaleId = (long)payment.SaleId,
                Amount = payment.Amount,
             
                Note = payment.Note,
           
            };
        }

        public static void UpdateModel(Payment payment, PaymentUpdatedDto dto)
        {
            payment.CustomerId = dto.CustomerId;
            payment.SaleId = dto.SaleId;
            payment.Amount = dto.Amount;
            payment.Date = dto.Date;
            payment.Note = dto.Note;
           
        }
    }
}
