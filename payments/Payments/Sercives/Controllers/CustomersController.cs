using Application.Models;
using Application.Requests;
using Application.Requests.Customers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Sercives.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("create-customer")]
        public async Task<IActionResult> Post([FromBody] CreateCustomerModel customer)
        {
            var request = new CreateCustomerRequest(customer);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("get-customer/{id}", Name = "GetCustomer")]
        public async Task<IActionResult> Get(string id)
        {
            var request = new GetCustomerRequest(new GetCustomerModel() { Id = id });
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("delete-customer/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var request = new DeleteCustomerRequest(new DeleteCustomerModel() { Id = id });
            var result = await _mediator.Send(request);

            if (result.IsDeleted == false)
                return BadRequest();

            return NoContent();
        }
    }
}