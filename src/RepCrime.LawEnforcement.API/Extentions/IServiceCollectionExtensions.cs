namespace RepCrime.LawEnforcement.API.Extentions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepCrimeLawEnforcementContext>(options => options
                .UseSqlServer(configuration["LawEnforcementConnectionString"]));
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ILawEnforecementRepository, LawEnforecementRepository>();
            services.AddScoped<IAssignCrimeRepository, AssignCrimeRepository>();
        }

        public static void AddCustomMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddScoped<LogHandlerMiddleware>();
        }
    }
}
