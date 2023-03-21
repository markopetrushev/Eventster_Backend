using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApp.Web.Data.Migrations
{
    public partial class changeFieldTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EventTickets",
                newName: "EventName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "EventTickets",
                newName: "Name");
        }
    }
}
