using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class removegroupfrommatchresult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchResult_GroupsStage_GroupId",
                table: "MatchResult");

            migrationBuilder.DropIndex(
                name: "IX_MatchResult_GroupId",
                table: "MatchResult");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "MatchResult");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "MatchResult",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchResult_GroupId",
                table: "MatchResult",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResult_GroupsStage_GroupId",
                table: "MatchResult",
                column: "GroupId",
                principalTable: "GroupsStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
