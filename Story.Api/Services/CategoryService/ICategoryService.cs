using Store.Api.Dtos.CategoryDTOs;

namespace Store.Api.Services.CategoryService
{
    public interface ICategoryService
    {
            Task<List<CategoryReadDto>> GetAllAsync();
            Task<CategoryReadDto> GetByIdAsync(long id);
            Task<CategoryReadDto> CreateAsync(CategoryCreateDto dto);
            Task<CategoryReadDto> UpdateAsync(long id, CategoryUpdateDto dto);
            Task<CategoryReadDto> DeleteAsync(long id);
        }
    }


