using MediatR;
using TraceApp.Application.Abstractions;
using TraceApp.Domain.Entities;
using TraceApp.Domain.Repositories;

namespace TraceApp.Application.Metrics.Commands.RecordMetric;

public sealed class RecordMetricCommandHandler(IApiRequestMetricRepository repository, IClock clock)
    : IRequestHandler<RecordMetricCommand>
{
    public async Task Handle(
        RecordMetricCommand command,
        CancellationToken cancellationToken)
    {
        var metric = new ApiRequestMetric
        {
            Id = Guid.NewGuid(),
            Service = command.Service,
            Endpoint = command.Endpoint,
            Method = command.Method,
            StatusCode = command.StatusCode,
            DurationMs = command.DurationMs,
            Timestamp = clock.UtcNow
        };

        await repository.AddAsync(metric, cancellationToken);
    }
}