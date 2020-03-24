using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Results.Plans
{
    public sealed class AllPlansResult
        : Result
    {
        public AllPlansResult(IEnumerable<GetPlanModel> plans)
        {
            Plans = plans ?? throw new ArgumentNullException(nameof(plans));
        }

        public IEnumerable<GetPlanModel> Plans { get; }
    }
}
