using Application.Options;
using Application.Requests.Sessions;
using Application.Results.Sessions;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Sessions
{
    public sealed class CreateSessionWithCustomerHandler
            : IRequestHandler<CreateSessionWithCustomerRequest, CreateSessionWithCustomerResult>
    {
        /// <summary>
        /// <see cref="SessionService"/> to use with communication with Stripe.
        /// </summary>
        private readonly SessionService _sessionService;

        /// <summary>
        /// <see cref="ILogger"/> use to logging.
        /// </summary>
        private readonly ILogger<CreateSessionWithCustomerHandler> _logger;

        private readonly IOptions<StripeOptions> _options;

        public CreateSessionWithCustomerHandler(SessionService sessionService, ILogger<CreateSessionWithCustomerHandler> logger, IOptions<StripeOptions> options)
        {
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<CreateSessionWithCustomerResult> Handle(CreateSessionWithCustomerRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var options = new SessionCreateOptions
            {
                Customer = request.Model.CustomerId,
                PaymentMethodTypes = _options.Value.PaymentMethodTypes,
                SubscriptionData = new SessionSubscriptionDataOptions
                {
                    
                    Items = new List<SessionSubscriptionDataItemOptions>
                    {
                        new SessionSubscriptionDataItemOptions
                        {
                            Plan = request.Model.PlanId
                        }
                    },
                    DefaultTaxRates = _options.Value.TaxIds
                },
                SuccessUrl = "https://example.com/success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://example.com/cancel"
            };
            var session = await _sessionService.CreateAsync(options, null, cancellationToken);

            CreateSessionWithCustomerResult result = new CreateSessionWithCustomerResult(session);

            return result;
        }
    }
}
