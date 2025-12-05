namespace Store.Api.Dtos.PaymentDTOs
{
    public class PaymentUpdatedDto
    {
        public long CustomerId { get; set; }      
        public long? SaleId { get; set; }         
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
    }
}
