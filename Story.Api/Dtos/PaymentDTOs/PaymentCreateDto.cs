namespace Store.Api.Dtos.PaymentDTOs
{
    public class PaymentCreateDto
    {
        public long CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
    }
}
