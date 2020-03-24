using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sercives.Configurations.Startups.ExceptionHandler
{
    public class ValidationExceptionMiddleware
    {
        /// <summary>
        /// <see cref="RequestDelegate"/> to use for calling the next
        /// middlware in the pipeline.
        /// </summary>
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            if (next == null)
                throw new ArgumentNullException(nameof(next));

            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));
            try
            {
                // Call the next middlware in the pipeline.
                await _next(httpContext);
            }
            catch (ValidationException validationException)
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                // Prepare inner error message objects to write.
                var innerErrors = validationException.Errors?.Select(x => new Error.InnerError()
                {
                    Code = x.ErrorCode,
                    Message = x.ErrorMessage,
                    Target = x.PropertyName
                });

                // Prepare error message object to write.
                var error = new Error()
                {
                    Code = "BadArguments",
                    Message = "One or more bad arguments",
                    Details = innerErrors
                };

                // Set content type to json as response type.
                httpContext.Response.ContentType = "application/json";

                // Status code.
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                // Wait error as json.
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(error, jsonSerializerOptions));
            }
        }

    }
}
