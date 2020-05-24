using System;
using System.Threading.Tasks;
using Application.Gateways;
using Application.Requests.Plans;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Sercives.Controllers
{
    public class ProductsController : Controller
    {
        private  ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("create")]
        public IActionResult Post([FromBody] string name)
        {
            var options = new ProductCreateOptions
            {
                Name = name
            };
            var result = _service.Create(options);
            var serviceGateway = new ServiceGateway();
            serviceGateway.CreateItem(name);
            return Ok(result);
        }

    }
}