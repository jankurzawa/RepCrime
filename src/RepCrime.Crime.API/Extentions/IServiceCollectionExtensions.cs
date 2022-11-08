namespace RepCrime.Crime.API.Extentions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IPublisher, AzureSender>();

            var mapConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new CrimeProfile());
            });
            var mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddCustomMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddScoped<LogHandlerMiddleware>();
        }
    }
}
