using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dev.Freela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(x => x.Email == email
                                     && x.Password == passwordHash);
        }
    }
}
