using Dev.Freela.Core.Entities;

namespace Dev.Freela.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);

        Task<User> GetByIdAsync(int id);
    }
}
