using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Commands.ProjectStart
{
    public class ProjectStartCommandHandler : IRequestHandler<ProjectStartCommand,Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectStartCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(ProjectStartCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            project.Start();

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
