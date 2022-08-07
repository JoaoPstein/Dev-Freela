using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dev.Freela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Skill>> GetAll()
        {
            return await _dbContext.Skills.ToListAsync();
        }
    }
}
