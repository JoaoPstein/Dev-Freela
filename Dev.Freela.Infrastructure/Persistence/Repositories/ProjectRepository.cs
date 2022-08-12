﻿using Dev.Freela.Core.Entities;
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

        public async Task<List<Project>> GetAllAsync()
        {
            return await _devFreelaDbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _devFreelaDbContext.Projects
              .Include(x => x.Client)
              .Include(x => x.Freelancer)
              .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Project project)
        {
            await _devFreelaDbContext.Projects.AddAsync(project);
            await _devFreelaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(x => x.Id == id);

            project.Cancell();
            await _devFreelaDbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _devFreelaDbContext.SaveChangesAsync();
        }
    }
}
