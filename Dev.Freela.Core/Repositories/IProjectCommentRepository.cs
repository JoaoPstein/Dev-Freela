﻿using Dev.Freela.Core.Entities;

namespace Dev.Freela.Core.Repositories
{
    public interface IProjectCommentRepository
    {
        Task CreateCommentAsync(ProjectComment projectComment);
    }
}
