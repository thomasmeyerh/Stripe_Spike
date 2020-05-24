using Application.Models;
using Application.Requests;
using Application.Results;
using Application.Validators;
using FluentValidation;
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
    public sealed class CreateCustomerHandler
            : IRequestHandler<CreateCustomerRequest, CreateCustomerResult>
    {
        /// <summary>
        /// <see cref="CustomerService"/> To use for get communication with Stripe.
        /// </summary>
        private readonly CustomerService _customerService;

        /// <summary>
        /// <see cref="ILogger{TCategoryName}"/> to use logging.
        /// </summary>
        private readonly ILogger<CreateCustomerHandler> _logger;

        /// <summary>
        /// <see cref="FluentValidation"/> to check for errrors in the model.
        /// </summary>
        private CreateCustomerValidator _validator;

        public CreateCustomerHandler(CustomerService customerService, ILogger<CreateCustomerHandler> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validator = new CreateCustomerValidator();
        }

        public async Task<CreateCustomerResult> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            _validator.ValidateAndThrow(request.Model);

            var options = new CustomerCreateOptions
            {
                
                Name = request.Model.Name,
                Email = request.Model.Email
            };

            var customer = await _customerService.CreateAsync(options, null, cancellationToken);

            _logger.LogInformation("Customer is created with ID: " + customer.Id);
            GetCustomerModel model = new GetCustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };

            CreateCustomerResult result = new CreateCustomerResult(model);

            return result;
        }
    }
}
