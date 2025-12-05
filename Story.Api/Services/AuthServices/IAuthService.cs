using Store.Api.Dtos.UserDTOs;
using Store.Api.Dtos;

namespace Store.Api.Services.AuthServices
{
    public interface IAuthService
    {
        Task<UserReadDto> RegisterAsync(UserRegisterDto dto);
        Task<LoginResultDto> LoginAsync(UserLoginDto dto);
        Task<UserReadDto> GetCurrentUserAsync(long userId);
    }
}
