using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Api Endpoint services

            // Application Use Case services

            // Data Infrastructure services
            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<CatalogDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }

        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
