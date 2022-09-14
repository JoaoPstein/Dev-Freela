using MediatR;

namespace Dev.Freela.Application.Commands.ProjectFinish
{
    public class ProjectFinishCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? CreditCardNumber { get; set; }
        public string? Cvv { get; set; }
        public string? ExpiresAt { get; set; }
        public string? FullName { get; set; }
    }
}
