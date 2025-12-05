using Store.Api.Dtos.UserDTOs;
using Store.Api.Models;

namespace Store.Api.Services.Mappings
{
    public static class UserMapping
    {
        public static User ToModel(UserCreateDto dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static UserReadDto ToReadDto(User user)
        {
            return new UserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public static void UpdateModel(User user, UserUpdateDto dto)
        {
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Role = dto.Role;
            user.UpdatedAt = DateTime.UtcNow;
        }
    }
}
