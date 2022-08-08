using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Queries.Projects
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAll();

            var projectsViewModel = projects
                .Select(x => new ProjectViewModel(x.Id, x.Title, x.CreatedAt))
                .ToList();

            return projectsViewModel;
        }
    }
}
