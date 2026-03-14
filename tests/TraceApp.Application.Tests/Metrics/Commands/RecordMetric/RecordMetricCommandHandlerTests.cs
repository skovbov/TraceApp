using NSubstitute;
using TraceApp.Application.Abstractions;
using TraceApp.Application.Metrics.Commands.RecordMetric;
using TraceApp.Domain.Entities;
using TraceApp.Domain.Repositories;

namespace TraceApp.Application.Tests.Metrics.Commands.RecordMetric;

public sealed class RecordMetricCommandHandlerTests
{
    private readonly IApiRequestMetricRepository _repository;
    private readonly IClock _clock;
    private readonly RecordMetricCommandHandler _handler;

    public RecordMetricCommandHandlerTests()
    {
        _repository = Substitute.For<IApiRequestMetricRepository>();
        _clock = Substitute.For<IClock>();
        _handler = new RecordMetricCommandHandler(_repository, _clock);
    }

    [Fact]
    public async Task Handle_Should_Save_Metric_With_Expected_Values()
    {
        // Arrange
        var now = new DateTime(2026, 3, 11, 12, 0, 0, DateTimeKind.Utc);
        _clock.UtcNow.Returns(now);

        var command = new RecordMetricCommand(
            Service: "order-api",
            Endpoint: "/orders",
            Method: "GET",
            StatusCode: 200,
            DurationMs: 125
        );

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _repository.Received(1).AddAsync(
            Arg.Is<ApiRequestMetric>(metric =>
                metric.Service == "order-api" &&
                metric.Endpoint == "/orders" &&
                metric.Method == "GET" &&
                metric.StatusCode == 200 &&
                metric.DurationMs == 125 &&
                metric.Timestamp == now),
            Arg.Any<CancellationToken>());
    }
}