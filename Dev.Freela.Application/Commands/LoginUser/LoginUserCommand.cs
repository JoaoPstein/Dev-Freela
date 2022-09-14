using Dev.Freela.Application.ViewModels;
using MediatR;

namespace Dev.Freela.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
