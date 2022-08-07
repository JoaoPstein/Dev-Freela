using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Commands.CreateProject
{
    internal class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository; 

        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository; 
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdClient,
               request.IdFreelancer, request.TotalCost);

            await _projectRepository.Create(project);

            return project.Id;
        }
    }
}
