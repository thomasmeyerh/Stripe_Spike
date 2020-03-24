using Application.Models;
using Application.Results.Plans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests.Plans
{
    public class AllPlansRequest
        : Request<GetPlanModel, AllPlansResult>
    {
        public AllPlansRequest(string correlationId = null) 
            : base(null, correlationId)
        { }
    }
}
