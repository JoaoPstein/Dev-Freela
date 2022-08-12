using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;

namespace Dev.Freela.Infrastructure.Persistence.Repositories
{
    public class ProjectCommentRepository : IProjectCommentRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectCommentRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCommentAsync(ProjectComment projectComment)
        {
            await _dbContext.AddAsync(projectComment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
