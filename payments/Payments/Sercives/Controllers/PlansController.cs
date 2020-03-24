using Application.Models;
using Application.Requests.Plans;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Sercives.Controllers
{
    [Route("api/[controller]")]
    public class PlansController : Controller
    {
        private readonly IMediator _mediator;

        public PlansController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var request = new AllPlansRequest();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

    }
}