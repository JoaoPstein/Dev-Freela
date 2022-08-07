using Dev.Freela.Application.Commands.CreateUsers;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Dev.Freela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido.");

            RuleFor(x => x.Password)
                .Must(ValidPassword);

            RuleFor(x => x.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome não pode ser vazio.");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"");

            return regex.IsMatch(password);
        }
    }
}
