using Store.Api.Dtos.ProductDTOs;
using Store.Api.Models;
using Store.Api.Repostories;
using Store.Api.Services.Mappings;

namespace Store.Api.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositoy _repo;

        public ProductService(IProductRepositoy repo)
        {
            _repo = repo;
        }

        public async Task<ProductReadDto> CreateAsync(ProductCreateDto dto)
        {
            var model = dto.ToModel();

            await _repo.AddAsync(model);

           
            var created = await _repo.GetByIdAsync(model.Id);

            return created!.ToReadDto();
        }

        public async Task<List<ProductReadDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(x => x.ToReadDto()).ToList();
        }

        public async Task<ProductReadDto?> GetByIdAsync(long id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product?.ToReadDto();
        }

        public async Task<ProductReadDto?> UpdateAsync(long id, ProductUpdateDto dto)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return null;

            product.UpdateDto(dto);
            product.UpdatedAt = DateTime.Now;

            await _repo.UpdateAsync(product);

            var updated = await _repo.GetByIdAsync(id);
            return updated!.ToReadDto();
        }

        public async Task<ProductReadDto?> DeleteAsync(long id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return null;

            var dto = product.ToReadDto();

            await _repo.DeleteAsync(product);

            return dto;
        }
    }
}
