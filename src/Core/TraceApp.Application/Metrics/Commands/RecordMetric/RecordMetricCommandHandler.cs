using MediatR;
using TraceApp.Domain.Entities;
using TraceApp.Domain.Repositories;

namespace TraceApp.Application.Metrics.Commands.RecordMetric;

public sealed class RecordMetricCommandHandler 
    : IRequestHandler<RecordMetricCommand>
{
    private readonly IApiRequestMetricRepository _repository;

    public RecordMetricCommandHandler(IApiRequestMetricRepository repository)
    {
        _repository = repository;
    }

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
            Timestamp = command.Timestamp
        };

        await _repository.AddAsync(metric, cancellationToken);
    }
}