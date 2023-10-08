using CapitalPlacement.Application.Common.Models;
using CapitalPlacement.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace CapitalPlacement.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = Result.Failure(error.Message);

                switch (error)
                {
                    case ValidationException e:
                        var errors = e.Errors.Values.SelectMany(a => a);
                        responseModel = Result.Failure(errors);
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ArgumentException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = "You are not authorized to access this resource";
                        break;
                    case UnauthorizedAccessException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        responseModel.Message = "You are not authorized to access this resource";
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                await response.WriteAsync(result);
            }
        }


    }
}
