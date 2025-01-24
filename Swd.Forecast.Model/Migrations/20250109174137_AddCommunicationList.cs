using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swd.Forecast.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddCommunicationList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunicationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunicationType = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CommunicationIdentifier = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SentDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    RecommendationId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationList", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CommunicationList_Recipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunicationList_Recommendation_RecommendationId",
                        column: x => x.RecommendationId,
                        principalTable: "Recommendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_CommunicationList",
                table: "CommunicationList",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationList_RecipientId",
                table: "CommunicationList",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationList_RecommendationId",
                table: "CommunicationList",
                column: "RecommendationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunicationList");
        }
    }
}
