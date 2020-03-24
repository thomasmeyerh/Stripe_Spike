using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Results
{
    public sealed class GetCustomerResult
    : Result
    {
        public GetCustomerResult(GetCustomerModel model)
        {
            Customer = model ?? throw new ArgumentNullException(nameof(model));
        }
        public GetCustomerModel Customer { get; }
    }
}
