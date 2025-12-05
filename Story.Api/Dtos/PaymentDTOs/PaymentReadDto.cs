namespace Store.Api.Dtos.PaymentDTOs
{
    public class PaymentReadDto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal Amount { get; set; }
      public long SaleId { get; set; }
        public string? Note { get; set; }
    }
}
