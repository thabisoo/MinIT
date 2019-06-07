using Microsoft.EntityFrameworkCore.Migrations;

namespace MinIT.Data.Migrations
{
    public partial class MeetingItemContraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingItems",
                table: "MeetingItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingItems",
                table: "MeetingItems",
                columns: new[] { "ItemId", "MeetingId" });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_MeetingId",
                table: "MeetingItems",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingItems",
                table: "MeetingItems");

            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_MeetingId",
                table: "MeetingItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingItems",
                table: "MeetingItems",
                columns: new[] { "MeetingId", "ItemId" });
        }
    }
}
