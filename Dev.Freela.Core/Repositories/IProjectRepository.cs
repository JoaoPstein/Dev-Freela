using Dev.Freela.Core.Entities;

namespace Dev.Freela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task CreateAsync(Project project);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
