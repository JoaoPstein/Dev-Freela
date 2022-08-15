using Dev.Freela.Core.DTOs;
using Dev.Freela.Core.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Infrastructure.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillDto>> GetAllAsync()
        {
            var skills = _dbContext.Skills;

            var skillsViewModel = skills
                .Select(s => new SkillDto(s.Id, s.Description))
                .ToList();

            return skillsViewModel;
        }
    }
}
