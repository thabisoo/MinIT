using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinIT.Data.Migrations
{
    public partial class AddStatusAndCommentFieldsOnItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_ItemId",
                table: "MeetingItems");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemStatusId",
                table: "Items",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_ItemId",
                table: "MeetingItems",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemStatusId",
                table: "Items",
                column: "ItemStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_MeetingItemStatuses_ItemStatusId",
                table: "Items",
                column: "ItemStatusId",
                principalTable: "MeetingItemStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_MeetingItemStatuses_ItemStatusId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_ItemId",
                table: "MeetingItems");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemStatusId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemStatusId",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_ItemId",
                table: "MeetingItems",
                column: "ItemId");
        }
    }
}
