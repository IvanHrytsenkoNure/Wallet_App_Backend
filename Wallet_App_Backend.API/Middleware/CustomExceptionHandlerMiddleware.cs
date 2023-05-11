using System.Net;
using System.Text;
using System.Text.Json;
using Wallet_App_Backend.Application.Common.Exceptions;
using ValidationException = FluentValidation.ValidationException;

namespace Wallet_App_Backend.API.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            string message;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    message = BuildErrorMessage(validationException);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                default:
                    message = exception.Message;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;


            return context.Response.WriteAsync(JsonSerializer.Serialize(new {error = message}));
        }

        protected string BuildErrorMessage(ValidationException e)
        {
            var sb = new StringBuilder();
            foreach (var error in e.Errors)
            {
                sb.Append(error.ErrorMessage);
                sb.Append(System.Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
