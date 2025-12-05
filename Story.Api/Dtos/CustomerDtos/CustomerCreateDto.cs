namespace Store.Api.Dtos.CustomerDto
{
    public class CustomerCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
