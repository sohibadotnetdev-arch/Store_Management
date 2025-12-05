using Store.Api.Dtos.CategoryDTOs;
using Store.Api.Repostories;
using Store.Api.Services.CategoryService;
using Store.Api.Services.Mappings;

namespace Store.Api.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        // Create
        public async Task<CategoryReadDto> CreateAsync(CategoryCreateDto dto)
        {
            var category = CategoryMapping.ToModel(dto); // CreateDto -> Model
            await _repo.AddAsync(category);
            return CategoryMapping.ToReadDto(category); // Model -> ReadDto
        }

        // Delete
        public async Task<CategoryReadDto> DeleteAsync(long id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) return null;

            await _repo.DeleteAsync(category);
            return CategoryMapping.ToReadDto(category);
        }

        // Get All
        public async Task<List<CategoryReadDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(CategoryMapping.ToReadDto).ToList();
        }

        // Get By Id
        public async Task<CategoryReadDto> GetByIdAsync(long id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) return null;
            return CategoryMapping.ToReadDto(category);
        }

        // Update
        public async Task<CategoryReadDto> UpdateAsync(long id, CategoryUpdateDto dto)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) return null;

            CategoryMapping.UpdateModel(category, dto); // UpdateDto -> Model
            await _repo.UpdateAsync(category);
            return CategoryMapping.ToReadDto(category);
        }
    }
}
