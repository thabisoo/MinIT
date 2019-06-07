using Microsoft.EntityFrameworkCore.Migrations;

namespace MinIT.Data.Migrations
{
    public partial class AddedMeetingItemInItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_ItemId",
                table: "MeetingItems");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_ItemId",
                table: "MeetingItems",
                column: "ItemId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_ItemId",
                table: "MeetingItems");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_ItemId",
                table: "MeetingItems",
                column: "ItemId");
        }
    }
}
