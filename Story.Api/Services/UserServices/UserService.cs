using Microsoft.EntityFrameworkCore;
using Store.Api.Dal;
using Store.Api.Dtos;
using Store.Api.Dtos.UserDTOs;
using Store.Api.Models;
using Store.Api.Repostories.UsersRepositories;
using Store.Api.Services.Mappings;

namespace Store.Api.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
        {
            // Email allaqachon mavjudligini tekshirish
            var existing = await _repo.GetByEmailAsync(dto.Email);
            if (existing != null)
                throw new Exception("Email already exists.");

            var user = UserMapping.ToModel(dto);
            await _repo.AddAsync(user);

            return UserMapping.ToReadDto(user);
        }

        public async Task<UserReadDto> GetByIdAsync(long id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return null;
            return UserMapping.ToReadDto(user);
        }

        public async Task<List<UserReadDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(UserMapping.ToReadDto).ToList();
        }

        public async Task<UserReadDto> UpdateAsync(long id, UserUpdateDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return null;

            UserMapping.UpdateModel(user, dto);
            await _repo.UpdateAsync(user);

            return UserMapping.ToReadDto(user);
        }

        public async Task<UserReadDto> DeleteAsync(long id)
        {
                var user = await _repo.GetByIdAsync(id);
                if (user == null) return null;

                await _repo.DeleteAsync(user); 
                return UserMapping.ToReadDto(user);
            }
    }
    }



