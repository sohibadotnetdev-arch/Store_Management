namespace Store.Api.Dtos.CustomerDto
{
    public class CustomerUpdateDto
    {
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
