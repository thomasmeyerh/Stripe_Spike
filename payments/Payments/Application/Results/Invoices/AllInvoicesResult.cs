using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Results.Invoices
{
    public sealed class AllInvoicesResult
        : Result
    {
        public AllInvoicesResult(IEnumerable<Invoice> invoices)
        {
            Invoices = invoices ?? throw new ArgumentNullException(nameof(invoices));
        }

        public IEnumerable<Invoice> Invoices { get; }
    }
}
