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
    public sealed class CreateSessionHandler
        : IRequestHandler<CreateSessionRequest, CreateSessionResult>
    {
        /// <summary>
        /// <see cref="SessionService"/> to use with communication with Stripe.
        /// </summary>
        private readonly SessionService _sessionService;

        /// <summary>
        /// <see cref="ILogger"/> use to logging.
        /// </summary>
        private readonly ILogger<CreateSessionHandler> _logger;

        private readonly IOptions<StripeOptions> _options;

        public CreateSessionHandler(SessionService sessionService, ILogger<CreateSessionHandler> logger, IOptions<StripeOptions> options)
        {
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<CreateSessionResult> Handle(CreateSessionRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var options = new SessionCreateOptions
            {
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
            CreateSessionResult result = new CreateSessionResult(session);

            return result;
        }
    }
}
