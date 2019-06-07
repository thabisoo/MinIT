using Microsoft.EntityFrameworkCore.Migrations;

namespace MinIT.Data.Migrations
{
    public partial class AddDefaultRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MeetingTypes(Id, Name, IsDeleted, CreatedAt, UpdatedAt) VALUES(newid(), 'MANCO', 'false', SYSDATETIMEOFFSET(), SYSDATETIMEOFFSET())");
            migrationBuilder.Sql("INSERT INTO MeetingItemStatuses(Id, Name, IsDeleted, CreatedAt, UpdatedAt) VALUES(newId(), 'Open', 'false', SYSDATETIMEOFFSET(), SYSDATETIMEOFFSET())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
