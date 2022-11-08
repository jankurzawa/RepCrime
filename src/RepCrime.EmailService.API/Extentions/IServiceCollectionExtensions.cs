namespace RepCrime.EmailService.API.Extentions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddHostedService<AzureEmailConsumer>();
        }

        public static void AddCustomMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddScoped<LogHandlerMiddleware>();
        }
    }
}
