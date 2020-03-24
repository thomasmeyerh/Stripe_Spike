using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Options
{
    public class StripeOptions
    {
        public string PublicKey { get; set; }
        public List<string> TaxIds { get; set; }

        public List<string> PaymentMethodTypes { get; set; }
    }
}
