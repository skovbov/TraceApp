using TraceApp.Domain.Entities;

namespace TraceApp.Domain.Repositories;

public interface IApiRequestMetricRepository
{
    Task AddAsync(ApiRequestMetric metric, CancellationToken cancellationToken = default);
}