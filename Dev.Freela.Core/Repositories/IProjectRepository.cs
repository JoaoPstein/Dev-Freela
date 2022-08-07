using Dev.Freela.Core.Entities;

namespace Dev.Freela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project> GetById(int id);
        Task Create(Project project);
        Task Delete(int id);
        Task SaveChanges();
    }
}
