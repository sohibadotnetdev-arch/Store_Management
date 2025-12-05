using Store.Api.Dtos.SaleDTOs;

namespace Store.Api.Services.SaleServices
{
    public interface ISaleService
    {
        Task<List<SaleReadDto>> GetAllAsync();
        Task<SaleReadDto?> GetByIdAsync(long id);
        Task<SaleReadDto> CreateAsync(SaleCreateDto dto);
        Task<SaleReadDto?> UpdateAsync(long id, SaleUpdateDto dto);
        Task<SaleReadDto?> DeleteAsync(long id);
    }
}
