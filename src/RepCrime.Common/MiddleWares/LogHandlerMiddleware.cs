namespace RepCrime.Common.MiddleWares
{
    public class LogHandlerMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public LogHandlerMiddleware(ILogger<LogHandlerMiddleware> logger)
            => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"({DateTime.Now}) {context.Request.Method}: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
            await next.Invoke(context);
            _logger.LogInformation($"({DateTime.Now}) RESPONSE STATUS CODE: {context.Response.StatusCode}\n");
        }
    }
}