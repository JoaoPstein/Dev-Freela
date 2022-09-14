using Dev.Freela.Application.Commands.CreateComment;
using Dev.Freela.Application.Commands.CreateProject;
using Dev.Freela.Application.Commands.DeleteProject;
using Dev.Freela.Application.Commands.ProjectFinish;
using Dev.Freela.Application.Commands.UpdateProject;
using Dev.Freela.Application.Queries.GetProjectById;
using Dev.Freela.Application.Queries.Projects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Freela.Api.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProject = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProject);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Client, Freelancer")]
        public IActionResult GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var projects = _mediator.Send(query);

            if (projects is null)
                return NotFound();

            return Ok(projects);
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectCommand updateProject)
        {
            if (updateProject is null)
                return BadRequest();

            await _mediator.Send(updateProject);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command.Id);

            return NoContent();
        }

        [HttpPost]
        [Route("/createComment")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}/finish")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id, [FromBody] ProjectFinishCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest("O pagamento não pôde ser processado.");

            return Accepted();
        }
    }
}
