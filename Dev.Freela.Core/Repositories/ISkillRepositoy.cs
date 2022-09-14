using Dev.Freela.Core.DTOs;

namespace Dev.Freela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<SkillDto>> GetAllAsync();
    }
}
