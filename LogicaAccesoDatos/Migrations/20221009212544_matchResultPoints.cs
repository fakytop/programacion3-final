using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class matchResultPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points_Away",
                table: "MatchResult",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points_Home",
                table: "MatchResult",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points_Away",
                table: "MatchResult");

            migrationBuilder.DropColumn(
                name: "Points_Home",
                table: "MatchResult");
        }
    }
}
