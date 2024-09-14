using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Trading.Application.Features.Positions.Commands.CreatePosition;
using Trading.Application.Features.Positions.Queries.GetAllPosition;
using Trading.Application.Features.Positions.Queries.GetLatestPositions;

namespace Trading.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpPost]
        [Route("CreatePosition", Name = "CreatePosition")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> CreatePosition([FromBody] CreatePositionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetLatestPositions", Name = "GetLatestPositions")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<LatestPosition>>> GetLatestPositions()
        {
            var result = await _mediator.Send(new GetLatestPositionsQuery { });
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllPositions", Name = "GetAllPositions")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetAllPosition>>> GetAllPositions()
        {
            var result = await _mediator.Send(new GetAllPositionQuery { });
            return Ok(result);
        }
    }
}
