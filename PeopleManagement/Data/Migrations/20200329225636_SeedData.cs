using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleManagement.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { 1, "COVID19 Negative" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 1);
        }
    }
}
