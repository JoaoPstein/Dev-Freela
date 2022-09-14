using Dev.Freela.Application.Commands.CreateProject;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Application.Validators
{
    [ExcludeFromCodeCoverage]
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de descrição é de 255 caracteres.");


            RuleFor(x => x.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo de título é de 30 caracteres.");
        }
    }
}
