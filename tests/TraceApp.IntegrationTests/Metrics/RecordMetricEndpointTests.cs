using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TraceApp.Infrastructure.Persistence;
using TraceApp.IntegrationTests.Infrastructure;

namespace TraceApp.IntegrationTests.Metrics;

public sealed class RecordMetricEndpointTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public RecordMetricEndpointTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task PostMetrics_Should_ReturnAccepted_AndPersistMetric()
    {
        // Arrange
        var client = _factory.CreateClient();

        var request = new
        {
            service = "order-api",
            endpoint = "/orders",
            method = "GET",
            statusCode = 200,
            durationMs = 125
        };
        
        // Act
        var response = await client.PostAsJsonAsync("/metrics", request);
        
        // Assert HTTP response
        response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        
        // Assert database state
        using var scope = _factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TraceLensDbContext>();

        dbContext.ApiRequestMetrics.Count().Should().Be(1);
    }

    [Fact]
    public async Task PostMetrics_Should_ReturnBadRequest_WhenCorruptedData()
    {
        // Arrange
        var client = _factory.CreateClient();

        var request = new
        {
            service = 1,
            endpoint = "/orders",
            method = "GET",
            statusCode = "",
            durationMs = 125
        };
        
        // Act
        var response = await client.PostAsJsonAsync("/metrics", request);
        
        // Assert HTTP response
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}