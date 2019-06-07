using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinIT.Data.Migrations
{
    public partial class CreateMeetingItemStatusHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetingItemStatusHistory",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    ItemStatusId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingItemStatusHistory", x => new { x.ItemId, x.ItemStatusId });
                    table.ForeignKey(
                        name: "FK_MeetingItemStatusHistory_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MeetingItemStatusHistory_MeetingItemStatuses_ItemStatusId",
                        column: x => x.ItemStatusId,
                        principalTable: "MeetingItemStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItemStatusHistory_ItemStatusId",
                table: "MeetingItemStatusHistory",
                column: "ItemStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingItemStatusHistory");
        }
    }
}
