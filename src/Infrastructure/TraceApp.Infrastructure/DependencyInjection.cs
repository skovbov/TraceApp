using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TraceApp.Domain.Repositories;
using TraceApp.Infrastructure.Persistence;
using TraceApp.Infrastructure.Repositories;

namespace TraceApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TraceLensDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("TraceAppDatabase")));

        services.AddScoped<IApiRequestMetricRepository, ApiRequestMetricRepository>();
        
        return services;
    }
}