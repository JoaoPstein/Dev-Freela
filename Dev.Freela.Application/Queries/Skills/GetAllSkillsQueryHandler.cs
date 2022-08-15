using Dev.Freela.Core.DTOs;
using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Queries.Skills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillQuery, List<SkillDto>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDto>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllAsync();
        }
    }
}
