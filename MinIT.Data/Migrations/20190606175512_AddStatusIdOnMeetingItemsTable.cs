using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinIT.Data.Migrations
{
    public partial class AddStatusIdOnMeetingItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemStatusId",
                table: "MeetingItems",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_ItemStatusId",
                table: "MeetingItems",
                column: "ItemStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingItems_MeetingItemStatuses_ItemStatusId",
                table: "MeetingItems",
                column: "ItemStatusId",
                principalTable: "MeetingItemStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingItems_MeetingItemStatuses_ItemStatusId",
                table: "MeetingItems");

            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_ItemStatusId",
                table: "MeetingItems");

            migrationBuilder.DropColumn(
                name: "ItemStatusId",
                table: "MeetingItems");
        }
    }
}
