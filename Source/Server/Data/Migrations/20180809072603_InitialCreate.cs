using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Herc.Pwa.Server.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "AssetDefinition",
                columns: table => new
                {
                    AssetDefinitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Logo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDefinition", x => x.AssetDefinitionId);
                });

            migrationBuilder.CreateTable(
                name: "MetricDefinition",
                columns: table => new
                {
                    AssetDefinitionId = table.Column<int>(nullable: false),
                    Default = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MetricDefinitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Regex = table.Column<string>(nullable: true),
                    SampleValue = table.Column<string>(nullable: true),
                    UnitOfMeasure = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricDefinition", x => x.MetricDefinitionId);
                    table.ForeignKey(
                        name: "FK_MetricDefinition_AssetDefinition_AssetDefinitionId",
                        column: x => x.AssetDefinitionId,
                        principalTable: "AssetDefinition",
                        principalColumn: "AssetDefinitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetricDefinition_AssetDefinitionId",
                table: "MetricDefinition",
                column: "AssetDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "MetricDefinition");

            migrationBuilder.DropTable(
                name: "AssetDefinition");
        }
    }
}
