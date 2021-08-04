using Application.Channels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private IMediator _mediator;
        public ChannelController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<Channel>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Channel>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id=id});
        }

        [HttpPost]
        public async Task<Unit> Create([FromBody]Create.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}
