using Store.Api.Dtos.CustomerDto;
using Store.Api.Models;
using Store.Api.Repostories.CustomerRepositories;

namespace Store.Api.Services.CustomServices
{
    public class CustomService : ICustomSevice
    {
        private readonly ICustomerRepository _repo;
        public CustomService(ICustomerRepository repository)
        {
            _repo = repository;
        }

        public async Task<CustomerReadDto> CreateAsync(CustomerCreateDto dto)
        {
            var customer = CustomerMapping.ToModel(dto);
            await _repo.AddAsync(customer);
            return CustomerMapping.ToReadDto(customer);
        }

        public async Task<List<CustomerReadDto>> GetAllAsync()
        {
            var customers = await _repo.GetAllAsync();
            return customers.Select(CustomerMapping.ToReadDto).ToList();
        }

        public async Task<CustomerReadDto?> GetByIdAsync(long id)
        {
            var customer = await _repo.GetByIdAsync(id);
            return customer == null ? null : CustomerMapping.ToReadDto(customer);
        }

        public async Task<CustomerReadDto?> UpdateAsync(long id, CustomerUpdateDto dto)
        {

            var customer = await _repo.GetByIdAsync(id);
            if (customer == null) return null;

            CustomerMapping.UpdateModel(customer, dto);
            await _repo.UpdateAsync(customer);
            return CustomerMapping.ToReadDto(customer);
        }

       public async  Task<CustomerReadDto?>  DeleteAsync(long id)
        {
            var customer = await _repo.DeleteAsync(id);
            return customer == null ? null : CustomerMapping.ToReadDto(customer);
        }
    }
}
