using Store.Api.Dtos.CustomerDto;
using Store.Api.Models;

namespace Store.Api.Services.CustomServices
{
    public interface ICustomSevice
    {
        Task<List<CustomerReadDto>> GetAllAsync();
        Task<CustomerReadDto?> GetByIdAsync(long id);
        Task<CustomerReadDto> CreateAsync(CustomerCreateDto dto);
        Task<CustomerReadDto?> UpdateAsync(long id, CustomerUpdateDto dto);
        Task<CustomerReadDto?> DeleteAsync(long id);
    }

}
