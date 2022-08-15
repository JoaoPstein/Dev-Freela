using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Infrastructure.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users
                .SingleAsync(x => x.Email == email
                                     && x.Password == passwordHash);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users
                .SingleAsync(x => x.Id == id);
        }
    }
}
