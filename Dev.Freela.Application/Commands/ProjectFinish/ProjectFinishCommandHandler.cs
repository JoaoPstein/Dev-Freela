using Dev.Freela.Core.DTOs;
using Dev.Freela.Core.Repositories;
using Dev.Freela.Infrastructure.Payments;
using MediatR;

namespace Dev.Freela.Application.Commands.ProjectFinish
{
    public class ProjectFinishCommandHandler : IRequestHandler<ProjectFinishCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPaymentService _paymentService;

        public ProjectFinishCommandHandler(IProjectRepository projectRepository, IPaymentService paymentService)
        {
            _projectRepository = projectRepository;
            _paymentService = paymentService;
        }

        public async Task<bool> Handle(ProjectFinishCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            var paymentInfoDto = new PaymentInfoDto(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, project.TotalCost);

            _paymentService.ProcessPayment(paymentInfoDto);

            project.SetPaymentPending();

            await _projectRepository.SaveChangesAsync();

            return true;
        }
    }
}
