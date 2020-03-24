using Application.Models;
using Application.Requests.Customers;
using Application.Results.Customers;
using MediatR;
using Microsoft.Extensions.Logging;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Customers
{
    public sealed class DeleteCustomerHandler
        : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResult>
    {

        /// <summary>
        /// <see cref="CustomerService"/> To use for get communication with Stripe.
        /// </summary>
        private readonly CustomerService _customerService;

        /// <summary>
        /// <see cref="ILogger{TCategoryName}"/> to use logging.
        /// </summary>
        private ILogger<DeleteCustomerHandler> _logger;

        public DeleteCustomerHandler(CustomerService customerService, ILogger<DeleteCustomerHandler> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<DeleteCustomerResult> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var customer = await _customerService.DeleteAsync(request.Model.Id, null, null, cancellationToken);

            _logger.LogInformation("Customer deleted with ID: " + customer.Id);

            DeleteCustomerResult result = new DeleteCustomerResult(isDeleted: true);

            return result;
        }
    }
}
