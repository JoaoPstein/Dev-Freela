using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dev.Freela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;
        public ProjectRepository(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public async Task<List<Project>> GetAll()
        {
            return await _devFreelaDbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            return await _devFreelaDbContext.Projects
              .Include(x => x.Client)
              .Include(x => x.Freelancer)
              .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Project project)
        {
            await _devFreelaDbContext.Projects.AddAsync(project);
            await _devFreelaDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(x => x.Id == id);

            project.Cancell();
            await _devFreelaDbContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _devFreelaDbContext.SaveChangesAsync();
        }
    }
}
