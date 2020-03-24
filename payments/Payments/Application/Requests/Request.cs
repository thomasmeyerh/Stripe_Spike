using Application.Models;
using Application.Results;
using MediatR;

namespace Application.Requests
{
    public abstract class Request<TModel, TResult>
       : IRequest<TResult> where TModel : Model where TResult : Result
    {
        public Request(TModel model, string correlationId = null)
        {

            Model = model;
            CorrelationId = correlationId;
        }

        /// <summary>
        /// Correlation id of request.
        /// </summary>
        public string CorrelationId { get; }

        /// <summary>
        /// Model of the request.
        /// </summary>
        public TModel Model { get; }
    }
}
