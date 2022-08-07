//using Dev.Freela.Core.Repositories;
//using MediatR;

//namespace Dev.Freela.Application.Queries.GetAllProjects
//{
//    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQueryHandler, List<ProjectViewModel>>
//    {
//        private readonly IProjectRepository _projectRepository;

//        public GetAllProjectQueryHandler(IProjectRepository projectRepository)
//        {
//            _projectRepository = projectRepository;
//        }

//        public async Task<List<ProjectViewModel>> Handle(GetAllProjectQueryHandler request, CancellationToken cancellationToken)
//        {
//            var projects = await _projectRepository.GetAll();

//            var projectsViewModel = projects
//                .Select(x => new ProjectViewModel(x.Id, x.Title, x.CreatedAt))
//                .ToList();

//            return projectsViewModel;
//        }
//    }
//}
