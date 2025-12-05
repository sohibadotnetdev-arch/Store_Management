using Store.Api.Dtos.PaymentDTOs;

namespace Store.Api.Dtos.CustomerDto
{
    public class CustomerReadDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public decimal TotalDebt { get; set; }
    }
}
