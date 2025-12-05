using Store.Api.Dtos.ProductDTOs;
using Store.Api.Dtos;

namespace Store.Api.Services.ProductServices
{
    public interface IProductService
    {
        Task<ProductReadDto> CreateAsync(ProductCreateDto dto);
        Task<List<ProductReadDto>> GetAllAsync();
        Task<ProductReadDto?> GetByIdAsync(long id);
        Task<ProductReadDto?> UpdateAsync(long id, ProductUpdateDto dto);
        Task<ProductReadDto?> DeleteAsync(long id);

    }
}


