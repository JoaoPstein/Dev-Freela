using Dev.Freela.Core.Entities;

namespace Dev.Freela.Core.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
