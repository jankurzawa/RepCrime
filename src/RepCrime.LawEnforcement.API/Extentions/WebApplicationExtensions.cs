namespace RepCrime.LawEnforcement.API.Extentions
{
    public static class WebApplicationExtensions
    {
        public static void UseCustomMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<LogHandlerMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
