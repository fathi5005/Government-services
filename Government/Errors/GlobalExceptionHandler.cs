using Microsoft.AspNetCore.Diagnostics;

namespace Government.Errors
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
           _logger.LogError(exception , "sometimes went wrong : {Message} ", exception.Message);

            var Problemdetails = new ProblemDetails()
            {

                Status= StatusCodes.Status500InternalServerError,
                Title ="InternalServerError",
                Type= "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"


            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(Problemdetails);
            return true;
        }
    }
}
