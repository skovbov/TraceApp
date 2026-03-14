using System.Reflection;
using TraceApp.Api.Endpoints.Metrics;
using TraceApp.Application.Metrics.Commands.RecordMetric;
using TraceApp.Domain.Entities;
using TraceApp.Infrastructure.Persistence;

namespace TraceApp.ArchitectureTests;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(ApiRequestMetric).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(RecordMetricCommandHandler).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(TraceLensDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(MapEndpoints).Assembly;
}