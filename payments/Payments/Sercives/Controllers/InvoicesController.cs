using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Requests.Invoices;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sercives.Controllers
{
    [Route("api/[controller]")]
    public class InvoicesController : Controller
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("all-by-customerId/{id}")]
        public async Task<IActionResult> All(string id)
        {
            var request = new AllInvociesRequest(new AllInvoicesByCustomerIdModel {CustomerId = id });
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}