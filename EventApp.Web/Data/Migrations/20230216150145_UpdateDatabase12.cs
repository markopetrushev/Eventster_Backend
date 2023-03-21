using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApp.Web.Data.Migrations
{
    public partial class UpdateDatabase12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "EventTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "EventTickets");
        }
    }
}
