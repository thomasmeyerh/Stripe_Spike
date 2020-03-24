using Application.Models;
using Application.Requests.Plans;
using Application.Results.Plans;
using MediatR;
using Microsoft.Extensions.Logging;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Plans
{
    public sealed class AllPlansHandler
        : IRequestHandler<AllPlansRequest, AllPlansResult>
    {
        /// <summary>
        /// <see cref="PlanService"/> to communicate with Stripe.
        /// </summary>
        private readonly PlanService _planService;

        /// <summary>
        /// <see cref="ProductService"/> to communicate with Stripe.
        /// </summary>
        private readonly ProductService _productService;

        /// <summary>
        /// <see cref="Logger{TCategoryName}"/> to use logging.
        /// </summary>
        private readonly ILogger<AllPlansHandler> _logger;

        public AllPlansHandler(PlanService planService, ProductService productService, ILogger<AllPlansHandler> logger)
        {
            _planService = planService ?? throw new ArgumentNullException(nameof(planService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AllPlansResult> Handle(AllPlansRequest request, CancellationToken cancellationToken)
        {
            List<GetPlanModel> returnlist = new List<GetPlanModel>();
            var plans = await _planService.ListAsync(null, null, cancellationToken);

            foreach (var plan in plans)
            {
                var product = await _productService.GetAsync(plan.ProductId, null, null, cancellationToken);

                var productModel = new GetPlanModel.ProductModel()
                {
                    Id = product.Id,
                    Name = product.Name
                };
                var planModel = new GetPlanModel()
                {
                    Id = plan.Id,
                    Amount = plan.Amount,
                    Product = productModel
                };
                returnlist.Add(planModel);
            }
            AllPlansResult result = new AllPlansResult(returnlist);

            return result;

        }
    }
}
