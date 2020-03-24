using Application.Models;
using Application.Requests;
using Application.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public sealed class GetCustomerHandler
    : IRequestHandler<GetCustomerRequest, GetCustomerResult>
    {
        /// <summary>
        /// <see cref="CustomerService"/> To use for get communication with Stripe.
        /// </summary>
        private readonly CustomerService _customerService;

        /// <summary>
        /// <see cref="ILogger{TCategoryName}"/> to use logging.
        /// </summary>
        private ILogger<GetCustomerHandler> _logger;

        public GetCustomerHandler(CustomerService customerService, ILogger<GetCustomerHandler> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetCustomerResult> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var customer = await _customerService.GetAsync(request.Model.Id, null, null, cancellationToken);

            if (customer == null)
                return null;

            GetCustomerModel model = new GetCustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };

            GetCustomerResult result = new GetCustomerResult(model);

            return result;
        }
    }
}
