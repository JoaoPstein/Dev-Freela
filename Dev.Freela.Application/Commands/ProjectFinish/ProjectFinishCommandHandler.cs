using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Commands.ProjectFinish
{
    public class ProjectFinishCommandHandler : IRequestHandler<ProjectFinishCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectFinishCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(ProjectFinishCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.Id);

            project.Finish();

            await _projectRepository.SaveChanges();

            return Unit.Value;
        }
    }
}
