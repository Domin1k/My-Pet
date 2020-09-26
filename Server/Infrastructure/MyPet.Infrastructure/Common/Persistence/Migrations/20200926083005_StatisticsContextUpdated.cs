namespace MyPet.Infrastructure.Common.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class StatisticsContextUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionAdView_AdoptionAdView_AdoptionAdId",
                table: "AdoptionAdView");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionAdView_Statistics_StatisticsId",
                table: "AdoptionAdView");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionAdView_AspNetUsers_UserId",
                table: "AdoptionAdView");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdoptionAdView",
                table: "AdoptionAdView");

            migrationBuilder.RenameTable(
                name: "AdoptionAdView",
                newName: "AdoptionAdViews");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionAdView_UserId",
                table: "AdoptionAdViews",
                newName: "IX_AdoptionAdViews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionAdView_StatisticsId",
                table: "AdoptionAdViews",
                newName: "IX_AdoptionAdViews_StatisticsId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionAdView_AdoptionAdId",
                table: "AdoptionAdViews",
                newName: "IX_AdoptionAdViews_AdoptionAdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdoptionAdViews",
                table: "AdoptionAdViews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionAdViews_AdoptionAdViews_AdoptionAdId",
                table: "AdoptionAdViews",
                column: "AdoptionAdId",
                principalTable: "AdoptionAdViews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionAdViews_Statistics_StatisticsId",
                table: "AdoptionAdViews",
                column: "StatisticsId",
                principalTable: "Statistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionAdViews_AspNetUsers_UserId",
                table: "AdoptionAdViews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionAdViews_AdoptionAdViews_AdoptionAdId",
                table: "AdoptionAdViews");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionAdViews_Statistics_StatisticsId",
                table: "AdoptionAdViews");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionAdViews_AspNetUsers_UserId",
                table: "AdoptionAdViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdoptionAdViews",
                table: "AdoptionAdViews");

            migrationBuilder.RenameTable(
                name: "AdoptionAdViews",
                newName: "AdoptionAdView");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionAdViews_UserId",
                table: "AdoptionAdView",
                newName: "IX_AdoptionAdView_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionAdViews_StatisticsId",
                table: "AdoptionAdView",
                newName: "IX_AdoptionAdView_StatisticsId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionAdViews_AdoptionAdId",
                table: "AdoptionAdView",
                newName: "IX_AdoptionAdView_AdoptionAdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdoptionAdView",
                table: "AdoptionAdView",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionAdView_AdoptionAdView_AdoptionAdId",
                table: "AdoptionAdView",
                column: "AdoptionAdId",
                principalTable: "AdoptionAdView",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionAdView_Statistics_StatisticsId",
                table: "AdoptionAdView",
                column: "StatisticsId",
                principalTable: "Statistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionAdView_AspNetUsers_UserId",
                table: "AdoptionAdView",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
