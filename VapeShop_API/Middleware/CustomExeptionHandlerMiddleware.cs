using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using VapeShop_API.ContractsExep;

namespace VapeShop_API.Middleware
{
    public class CustomExeptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public CustomExeptionHandlerMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var message = string.Empty;
            switch (ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    message = JsonSerializer.Serialize(validationException.Message);
                    break;
                case DbConnectionExeption:
                    code = HttpStatusCode.BadRequest;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (message == string.Empty)
            {
                message = JsonSerializer.Serialize(new { error = ex.Message });
            }
            return context.Response.WriteAsync(message);
        }
    }
}
