using Microsoft.EntityFrameworkCore.Migrations;

namespace MinIT.Data.Migrations
{
    public partial class AddedStatusIdContraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingItems",
                table: "MeetingItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingItems",
                table: "MeetingItems",
                columns: new[] { "MeetingId", "ItemId", "ItemStatusId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingItems",
                table: "MeetingItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingItems",
                table: "MeetingItems",
                columns: new[] { "MeetingId", "ItemId" });
        }
    }
}
