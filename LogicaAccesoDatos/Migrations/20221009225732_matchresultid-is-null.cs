using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class matchresultidisnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchResult_Match_MatchId",
                table: "MatchResult");

            migrationBuilder.DropIndex(
                name: "IX_MatchResult_MatchId",
                table: "MatchResult");

            migrationBuilder.AddColumn<int>(
                name: "MatchId1",
                table: "MatchResult",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchResultId",
                table: "Match",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchResult_MatchId1",
                table: "MatchResult",
                column: "MatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchResultId",
                table: "Match",
                column: "MatchResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match",
                column: "MatchResultId",
                principalTable: "MatchResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResult_Match_MatchId1",
                table: "MatchResult",
                column: "MatchId1",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchResult_Match_MatchId1",
                table: "MatchResult");

            migrationBuilder.DropIndex(
                name: "IX_MatchResult_MatchId1",
                table: "MatchResult");

            migrationBuilder.DropIndex(
                name: "IX_Match_MatchResultId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "MatchId1",
                table: "MatchResult");

            migrationBuilder.DropColumn(
                name: "MatchResultId",
                table: "Match");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResult_MatchId",
                table: "MatchResult",
                column: "MatchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResult_Match_MatchId",
                table: "MatchResult",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
