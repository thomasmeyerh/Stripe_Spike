using Application.Models;
using Application.Requests.Sessions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Threading.Tasks;

namespace Sercives.Controllers
{
    [Route("api/[controller]")]
    public class SessionsController : Controller
    {
        private readonly IMediator _mediator;

        public SessionsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("Public-key")]
        public string GetPublicKey()
        {
            return "hej";
        }

        [HttpPost("create-session")]
        public async Task<IActionResult> Post([FromBody] CreateSessionModel model)
        {
            var request = new CreateSessionRequest(model);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("create-session-with-customer")]
        public async Task<IActionResult> Post([FromBody] CreateSessionWithCustomerModel model)
        {
            var request = new CreateSessionWithCustomerRequest(model);
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}