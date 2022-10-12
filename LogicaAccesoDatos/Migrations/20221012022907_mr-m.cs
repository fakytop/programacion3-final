using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class mrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchResult_Match_MatchId1",
                table: "MatchResult");

            migrationBuilder.DropIndex(
                name: "IX_MatchResult_MatchId1",
                table: "MatchResult");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "MatchResult");

            migrationBuilder.DropColumn(
                name: "MatchId1",
                table: "MatchResult");

            migrationBuilder.AddColumn<int>(
                name: "MatchResultId1",
                table: "Match",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchResultId1",
                table: "Match",
                column: "MatchResultId1",
                unique: true,
                filter: "[MatchResultId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_MatchResult_MatchResultId1",
                table: "Match",
                column: "MatchResultId1",
                principalTable: "MatchResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_MatchResult_MatchResultId1",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_MatchResultId1",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "MatchResultId1",
                table: "Match");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "MatchResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchId1",
                table: "MatchResult",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchResult_MatchId1",
                table: "MatchResult",
                column: "MatchId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResult_Match_MatchId1",
                table: "MatchResult",
                column: "MatchId1",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
