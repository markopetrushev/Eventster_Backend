using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApp.Web.Data.Migrations
{
    public partial class UpdateDatabase13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "EventTickets",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EventTickets",
                newName: "Title");
        }
    }
}
