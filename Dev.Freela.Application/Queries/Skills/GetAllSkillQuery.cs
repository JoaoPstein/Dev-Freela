using Dev.Freela.Core.DTOs;
using MediatR;

namespace Dev.Freela.Application.Queries.Skills
{
    public class GetAllSkillQuery : IRequest<List<SkillDto>>
    {
    }
}
