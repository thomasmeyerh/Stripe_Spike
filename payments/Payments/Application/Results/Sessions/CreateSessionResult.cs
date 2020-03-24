using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Results.Sessions
{
    public sealed class CreateSessionResult
        : Result
    {
        public CreateSessionResult(Session model)
        {
            Session = model ?? throw new ArgumentNullException(nameof(model));
        }

        public Session Session { get; set; }
    }
}
