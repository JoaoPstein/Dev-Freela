//using Dev.Freela.Core.Repositories;
//using MediatR;

//namespace Dev.Freela.Application.Queries.GetAllSkills
//{
//    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
//    {
//        private readonly ISkillRepository _skillRepositoy;

//        public GetAllSkillsQueryHandler(ISkillRepository skillRepositoy)
//        {
//            _skillRepositoy = skillRepositoy;   
//        }

//        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
//        {
//            var skills = await _skillRepositoy.GetAll();

//            var skillsViewModel = skills
//                .Select(x => new SkillViewModel(x.Id, x.Description))
//                .ToList();

//            return skillsViewModel;
//        }
//    }
//}
