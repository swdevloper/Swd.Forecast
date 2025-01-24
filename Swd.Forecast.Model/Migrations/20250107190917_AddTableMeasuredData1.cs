using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swd.Forecast.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddTableMeasuredData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasuredData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasuredValue = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MeasuredDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    TypeOfMeasuredDataId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuredData", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_MeasuredData_TypeOfMeasuredData_TypeOfMeasuredDataId",
                        column: x => x.TypeOfMeasuredDataId,
                        principalTable: "TypeOfMeasuredData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_MeasuredData",
                table: "MeasuredData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuredData_TypeOfMeasuredDataId",
                table: "MeasuredData",
                column: "TypeOfMeasuredDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasuredData");
        }
    }
}
