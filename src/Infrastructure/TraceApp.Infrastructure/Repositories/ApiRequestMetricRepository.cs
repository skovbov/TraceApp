using TraceApp.Domain.Entities;
using TraceApp.Domain.Repositories;
using TraceApp.Infrastructure.Persistence;

namespace TraceApp.Infrastructure.Repositories;

public sealed class ApiRequestMetricRepository(TraceLensDbContext dbContext) : IApiRequestMetricRepository
{
    public async Task AddAsync(
        ApiRequestMetric metric,
        CancellationToken cancellationToken = default)
    {
        await dbContext.ApiRequestMetrics.AddAsync(metric, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}