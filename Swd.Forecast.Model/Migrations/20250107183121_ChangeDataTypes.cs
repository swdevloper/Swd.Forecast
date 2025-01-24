using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swd.Forecast.Model.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfRecommendation",
                table: "TypeOfRecommendation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfMeasuredData",
                table: "TypeOfMeasuredData");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TypeOfRecommendation",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TypeOfMeasuredData",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfRecommendation",
                table: "TypeOfRecommendation",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfMeasuredData",
                table: "TypeOfMeasuredData",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "idx_TypeOfRecommendation",
                table: "TypeOfRecommendation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "idx_TypeOfMeasuredData",
                table: "TypeOfMeasuredData",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfRecommendation",
                table: "TypeOfRecommendation");

            migrationBuilder.DropIndex(
                name: "idx_TypeOfRecommendation",
                table: "TypeOfRecommendation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfMeasuredData",
                table: "TypeOfMeasuredData");

            migrationBuilder.DropIndex(
                name: "idx_TypeOfMeasuredData",
                table: "TypeOfMeasuredData");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TypeOfRecommendation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TypeOfMeasuredData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfRecommendation",
                table: "TypeOfRecommendation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfMeasuredData",
                table: "TypeOfMeasuredData",
                column: "Id");
        }
    }
}
