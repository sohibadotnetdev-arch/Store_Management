using Jose.native;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.Api.Dal;
using Store.Api.Dtos;
using Store.Api.Dtos.UserDTOs;
using Store.Api.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Store.Api.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly StoreDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(StoreDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        // ===================== REGISTER =====================

        public async Task<UserReadDto> RegisterAsync(UserRegisterDto dto)
        {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Email already exists.");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                Role = "Cashier",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

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

        public async Task<LoginResultDto> LoginAsync(UserLoginDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                throw new Exception("Invalid credentials.");

            var token = GenerateJwtToken(user);

            return new LoginResultDto
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                AccessToken = token,
                ExpiresIn = int.Parse(_config["Jwt:ExpiresInMinutes"]) * 60
            };
        }

        public async Task<UserReadDto> GetCurrentUserAsync(long userId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null) throw new Exception("User not found.");

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

        // Password hash (BCrypt tavsiya qilinadi)
        private string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        private bool VerifyPassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);

        // JWT token yaratish
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
