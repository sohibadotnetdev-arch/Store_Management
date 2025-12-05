using Store.Api.Dtos.UserDTOs;

namespace Store.Api.Dtos
{
    public class LoginResultDto
    {
        public long UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public int ExpiresIn { get; set; }
    }
}
