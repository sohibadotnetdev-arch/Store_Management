using Store.Api.Dtos;
using Store.Api.Dtos.UserDTOs;
using Store.Api.Models;

namespace Store.Api.Services.UserServices
{
    public interface IUserService
    {
        Task<UserReadDto> CreateAsync(UserCreateDto dto);
        Task<UserReadDto> GetByIdAsync(long id);
        Task<List<UserReadDto>> GetAllAsync();
        Task<UserReadDto> UpdateAsync(long id, UserUpdateDto dto);
        Task<UserReadDto> DeleteAsync(long id);
    }
}
