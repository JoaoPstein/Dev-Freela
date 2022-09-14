using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Queries.GetUsers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                return new UserViewModel("", "");

            var userViewModel = new UserViewModel(user.Name, user.Email);

            return userViewModel;
        }
    }
}
