using Store.Api.Models;

namespace Store.Api.Repostories.UsersRepositories
{
    public  interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(long id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(long id);

        Task<User> GetByEmailAsync(string email);
        Task DeleteAsync(User user);
    }
}
