using Dev.Freela.Application.Commands.CreateComment;
using Dev.Freela.Application.Commands.DeleteProject;
using Dev.Freela.Application.Commands.UpdateProject;
using Dev.Freela.Application.InputModels.Projects;
using Dev.Freela.Application.Queries.GetAllProjects;
using Dev.Freela.Application.Queries.GetProjectById;
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
        [Authorize(Roles = "client, freelancer")]
        public IActionResult GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var projects = _mediator.Send(query);

            if (projects is null)
                return NotFound();

            return Ok(projects);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand updateProject)
        {
            if (updateProject is null)
                return BadRequest();

            await _mediator.Send(updateProject);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
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
    }
}
