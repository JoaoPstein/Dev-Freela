using Dev.Freela.Core.DTOs;
using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Queries.Skills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillQuery, List<SkillDTO>>
    {
        private readonly ISkillRepository _skillRepository;
        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAll();
        }
    }
}
