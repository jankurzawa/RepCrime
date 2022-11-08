namespace RepCrime.MVC.Extentions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICrimeService, CrimeService>();
            services.AddScoped<IStatsService, StatsService>();
        }

        public static void AddCustomMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddScoped<LogHandlerMiddleware>();
        }
    }
}
