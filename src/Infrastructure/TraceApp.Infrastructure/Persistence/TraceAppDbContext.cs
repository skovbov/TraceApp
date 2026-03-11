using Microsoft.EntityFrameworkCore;
using TraceApp.Domain.Entities;

namespace TraceApp.Infrastructure.Persistence;

public sealed class TraceLensDbContext(DbContextOptions<TraceLensDbContext> options) : DbContext(options)
{
    public DbSet<ApiRequestMetric> ApiRequestMetrics => Set<ApiRequestMetric>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApiRequestMetric>(entity =>
        {
            entity.ToTable("api_request_metrics");

            entity.HasKey(x => x.Id);

            entity.HasIndex(x => x.Timestamp);
            entity.HasIndex(x => new { x.Service, x.Endpoint });
        });
    }
}