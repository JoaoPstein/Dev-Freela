using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Commands.DeleteProject
{
    internal class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            await _projectRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
