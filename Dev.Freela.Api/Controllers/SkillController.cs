using Dev.Freela.Application.Queries.Skills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Freela.Api.Controllers
{
    public class SkillController : Controller
    {
        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSkillQuery();

            var skills = await _mediator.Send(query);

            return Ok(skills);
        }
    }
}
