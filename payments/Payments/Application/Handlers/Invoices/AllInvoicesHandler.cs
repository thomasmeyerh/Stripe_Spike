using Application.Requests.Invoices;
using Application.Results.Invoices;
using MediatR;
using Microsoft.Extensions.Logging;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Invoices
{
    public sealed class AllInvoicesHandler
           : IRequestHandler<AllInvociesRequest, AllInvoicesResult>
    {
        /// <summary>
        /// <see cref="InvoiceService"/> to communicate with Stripe.
        /// </summary>
        private readonly InvoiceService _invoiceService;

        /// <summary>
        /// <see cref="Logger{TCategoryName}"/> to use logging.
        /// </summary>
        private readonly ILogger<AllInvoicesHandler> _logger;

        public AllInvoicesHandler(InvoiceService invoiceService, ILogger<AllInvoicesHandler> logger)
        {
            _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AllInvoicesResult> Handle(AllInvociesRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request))
            }

            var options = new InvoiceListOptions
            {
                Customer = request.Model.CustomerId
            };

            var invoices = await _invoiceService.ListAsync(options, null, cancellationToken);

            AllInvoicesResult result = new AllInvoicesResult(invoices);

            return result;
        }
    }
}
