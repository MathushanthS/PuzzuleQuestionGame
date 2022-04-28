using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzuleQuestion.MediatorQueries.AnswerQuery;

namespace PuzzuleQuestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private IMediator _mediator;

        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddAnswers")]
        public async Task<IActionResult> AddAnswer(AddAnswerQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);


        }
        [HttpGet("GetAnswerByUserId")]
        public async Task<IActionResult> getAnswerById(int UserId)
        {
            var result =await _mediator.Send(new GetAnswerByUserIdQuery { UserId = UserId });
            return Ok(result);

        }

        [HttpPost("EnterValuesTocheck")]
        public async Task<IActionResult> EnterValuesTocheck(CheckerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}
