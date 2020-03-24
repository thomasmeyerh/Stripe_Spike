using Application.Models;
using Application.Results.Invoices;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests.Invoices
{
    public class AllInvociesRequest
      : Request<AllInvoicesByCustomerIdModel, AllInvoicesResult>
    {
        public AllInvociesRequest(AllInvoicesByCustomerIdModel model, string correlationId = null)
            : base(model, correlationId)
        { }
    }
}
