using Dev.Freela.Core.DTOs;
using Dev.Freela.Core.Repositories;

namespace Dev.Freela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillDTO>> GetAll()
        {
            throw new NotImplementedException();
           //var skills = _dbContext.Skills;

           // var skillsViewModel = skills
           //     //.Select(s => new SkillViewModel(s.Id, s.Description))
           //     .ToList();

           // return skillsViewModel;
        }
    }
}
