    namespace Store.Api.Dtos.CategoryDTOs
{
    public class CategoryReadDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int ProductCount { get; set; }
    }
}
