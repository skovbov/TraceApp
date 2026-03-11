using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraceApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "api_request_metrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Service = table.Column<string>(type: "text", nullable: false),
                    Endpoint = table.Column<string>(type: "text", nullable: false),
                    Method = table.Column<string>(type: "text", nullable: false),
                    StatusCode = table.Column<int>(type: "integer", nullable: false),
                    DurationMs = table.Column<long>(type: "bigint", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_api_request_metrics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_api_request_metrics_Service_Endpoint",
                table: "api_request_metrics",
                columns: new[] { "Service", "Endpoint" });

            migrationBuilder.CreateIndex(
                name: "IX_api_request_metrics_Timestamp",
                table: "api_request_metrics",
                column: "Timestamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "api_request_metrics");
        }
    }
}
