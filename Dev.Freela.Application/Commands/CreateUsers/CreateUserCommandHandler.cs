using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using Dev.Freela.Core.Services;
using MediatR;

namespace Dev.Freela.Application.Commands.CreateUsers
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;   
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await _userRepository.Create(user);

            return user.Id;
        }
    }
}
