using Dev.Freela.Application.Commands.CreateUsers;
using Dev.Freela.Application.Commands.LoginUser;
using Dev.Freela.Application.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Freela.Api.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id) 
        {
            var query = new GetUserByIdQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut("/login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginUserCommand loginUserCommand)
        {
            var loginUserViewModel = _mediator.Send(loginUserCommand);

            if (loginUserViewModel is null)
                return BadRequest();

            return Ok(loginUserViewModel);
        }
    }
}
