using Dev.Freela.Core.Entities;

namespace Dev.Freela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAll();
    }
}
