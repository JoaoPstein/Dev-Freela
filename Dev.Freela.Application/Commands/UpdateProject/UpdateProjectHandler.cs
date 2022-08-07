using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Commands.UpdateProject
{
    internal class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);

            await _projectRepository.SaveChanges();

            return Unit.Value;
        }
    }
}
