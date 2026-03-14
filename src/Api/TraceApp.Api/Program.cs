using TraceApp.Api.Endpoints.Metrics;
using TraceApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(TraceApp.Application.Metrics.Commands.RecordMetric.RecordMetricCommand).Assembly);
});
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapMetricsEndpoints();
app.UseHttpsRedirection();

app.Run();