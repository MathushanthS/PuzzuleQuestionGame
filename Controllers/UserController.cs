using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzuleQuestion.MediatorQueries.User;

namespace PuzzuleQuestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(AddUserCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);


        }
    }
}
