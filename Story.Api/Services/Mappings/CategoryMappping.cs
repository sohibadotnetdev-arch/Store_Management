using Store.Api.Dtos.CategoryDTOs;
using Store.Api.Models;

namespace Store.Api.Services.Mappings
{
    public static class CategoryMapping
    {
        public static Category ToModel(CategoryCreateDto dto)
        {
            return new Category
            {
                Name = dto.Name
            };
        }

        public static CategoryReadDto ToReadDto(Category category)
        {
            return new CategoryReadDto
            {
                Id = category.Id,
                Name = category.Name,
                
            };
        }

        public static void UpdateModel(Category category, CategoryUpdateDto dto)
        {
            category.Name = dto.Name;
        }
    }
}
