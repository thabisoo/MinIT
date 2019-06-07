using Microsoft.EntityFrameworkCore.Migrations;

namespace MinIT.Data.Migrations
{
    public partial class AddedMeetingLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_MeetingId",
                table: "MeetingItems",
                column: "MeetingId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_MeetingId",
                table: "MeetingItems");
        }
    }
}
