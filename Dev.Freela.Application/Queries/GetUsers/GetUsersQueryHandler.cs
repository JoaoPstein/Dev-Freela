﻿using Dev.Freela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dev.Freela.Application.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetUsersQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user == null)
                return new UserViewModel("", "");

            return new UserViewModel(user.Name, user.Email);
        }
    }
}
