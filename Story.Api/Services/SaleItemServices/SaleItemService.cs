using Store.Api.Dtos.SaleItemDTOs;
using Store.Api.Repostories.SaleItemsRepositories;
using Store.Api.Services.Mappings;

namespace Store.Api.Services.SaleItemServices
{
    public class SaleItemService:ISaleItemService
    {

             private readonly ISaleItemsRepository _repo;

            public SaleItemService(ISaleItemsRepository repository)
            {
                _repo = repository;
            }

            public async Task<List<SaleItemReadDto>> GetAllAsync()
            {
                var items = await _repo.GetAllAsync();
                return items.Select(SaleItemMapping.ToReadDto).ToList();
            }

            public async Task<SaleItemReadDto?> GetByIdAsync(long id)
            {
                var item = await _repo.GetByIdAsync(id);
                if (item == null) return null;
                return SaleItemMapping.ToReadDto(item);
            }

          
            public async Task AddAsync(SaleItemCreateDto dto)
            {
                var item = SaleItemMapping.ToModel(dto);
                await _repo.AddAsync(item);
            }

            public async Task UpdateAsync(long id, SaleItemUpdateDto dto)
            {
                var item = await _repo.GetByIdAsync(id);
                if (item == null) return;

                SaleItemMapping.UpdateModel(item, dto);
                await _repo.UpdateAsync(item);
            }

            public async Task DeleteAsync(long id)
            {
                await _repo.DeleteAsync(id);
            }
        }
    }

