namespace RepCrime.Common.MiddleWares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
            => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try { await next.Invoke(context); }
            catch (BadHostNameException badHostNameException)
            {
                await HandleExceptionAsync(context, badHostNameException, HttpStatusCode.NotFound).ConfigureAwait(false);
            }
            catch (CannotAssignCrimeToLawEnforcementException cannotAssignCrimeToLawEnforcementException)
            {
                await HandleExceptionAsync(context, cannotAssignCrimeToLawEnforcementException, HttpStatusCode.NotFound).ConfigureAwait(false);
            }
            catch (CannotSendEmailException cannotSendEmailException)
            {
                await HandleExceptionAsync(context, cannotSendEmailException, HttpStatusCode.NotFound).ConfigureAwait(false);
            }
            catch (NoLawEnforcementAssignedException noLawEnforcementAssignedException)
            {
                await HandleExceptionAsync(context, noLawEnforcementAssignedException, HttpStatusCode.NotFound).ConfigureAwait(false);
            }
            catch (StatisticCalculatingException statisticCalculatingException)
            {
                await HandleExceptionAsync(context, statisticCalculatingException, HttpStatusCode.NotFound).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                _logger.LogError($"({DateTime.Now}) Unhandled Exception: {context.Request.Method}: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}\n\n{exception.Message}\n{exception}");
                await HandleExceptionAsync(context, exception, HttpStatusCode.InternalServerError).ConfigureAwait(false);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsJsonAsync(new { Error = exception.Message });
        }
    }
}