using Dev.Freela.Application.Commands.CreateProject;
using FluentValidation;

namespace Dev.Freela.Application.Validators
{
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
