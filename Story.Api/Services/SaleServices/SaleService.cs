using Store.Api.Dtos.SaleDTOs;
using Store.Api.Models;
using Store.Api.Repostories.SelesRepositories;
using Store.Api.Services.Mappings;


namespace Store.Api.Services.SaleServices
    {
        public class SaleService : ISaleService
        {
            private readonly ISaleRepository _repo;

            public SaleService(ISaleRepository saleRepo)
            {
                _repo = saleRepo;
            }

            public async Task<List<SaleReadDto>> GetAllAsync()
            {
                var list = await _repo.GetAllAsync();
                return list.Select(SaleMapping.ToReadDto).ToList();
            }

            public async Task<SaleReadDto?> GetByIdAsync(long id)
            {
                var sale = await _repo.GetByIdAsync(id);
                return sale == null ? null : SaleMapping.ToReadDto(sale);
            }

            public async Task<SaleReadDto> CreateAsync(SaleCreateDto dto)
            {
                var model = SaleMapping.ToModel(dto);

                await _repo.AddAsync(model);

                var created = await _repo.GetByIdAsync(model.Id);
                return SaleMapping.ToReadDto(created!);
            }

            public async Task<SaleReadDto?> UpdateAsync(long id, SaleUpdateDto dto)
            {
                var sale = await _repo.GetByIdAsync(id);
                if (sale == null) return null;

                // DTO → Model
                SaleMapping.UpdateModel(sale, dto);

                // Itemsni yangidan qo‘shish
                sale.Items = dto.Items.Select(i => new SaleItem
                {
                    ProductId = i.ProductId,
                    Qty = i.Qty,
                    UnitPrice = i.UnitPrice,
                    TotalPrice = i.Qty * i.UnitPrice
                }).ToList();

                await _repo.UpdateAsync(sale);

                var updated = await _repo.GetByIdAsync(id);
                return SaleMapping.ToReadDto(updated!);
            }

            public async Task<SaleReadDto?> DeleteAsync(long id)
            {
                var sale = await _repo.GetByIdAsync(id);
                if (sale == null) return null;

                var dto = SaleMapping.ToReadDto(sale);

                await _repo.DeleteAsync(id);

                return dto;
            }
        }
    }


