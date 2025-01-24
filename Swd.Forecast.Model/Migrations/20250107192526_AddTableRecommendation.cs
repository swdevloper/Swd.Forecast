using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swd.Forecast.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddTableRecommendation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recommendation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variable = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TypeOfRecommendationId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendation", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Recommendation_TypeOfRecommendation_TypeOfRecommendationId",
                        column: x => x.TypeOfRecommendationId,
                        principalTable: "TypeOfRecommendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_Recommendation",
                table: "Recommendation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendation_TypeOfRecommendationId",
                table: "Recommendation",
                column: "TypeOfRecommendationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recommendation");
        }
    }
}
