namespace MyPet.Infrastructure.Common.Persistence.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class StatisticsSetAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAdoptionAds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdoptionAdView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    AdoptionAdId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    StatisticsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionAdView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdoptionAdView_AdoptionAdView_AdoptionAdId",
                        column: x => x.AdoptionAdId,
                        principalTable: "AdoptionAdView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdoptionAdView_Statistics_StatisticsId",
                        column: x => x.StatisticsId,
                        principalTable: "Statistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdoptionAdView_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionAdView_AdoptionAdId",
                table: "AdoptionAdView",
                column: "AdoptionAdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionAdView_StatisticsId",
                table: "AdoptionAdView",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionAdView_UserId",
                table: "AdoptionAdView",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionAdView");

            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
