using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryConsoleApp.Migrations
{
    public partial class AddMemberEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Member",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BookLog",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BookLog");
        }
    }
}
