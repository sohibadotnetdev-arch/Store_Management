using Store.Api.Dtos.SaleItemDTOs;

namespace Store.Api.Services.SaleItemServices
{
    public interface ISaleItemService
    {
        Task<List<SaleItemReadDto>> GetAllAsync();
        Task<SaleItemReadDto?> GetByIdAsync(long id);
        Task AddAsync(SaleItemCreateDto dto);
        Task UpdateAsync(long id, SaleItemUpdateDto dto);
        Task DeleteAsync(long id);

    }
}


