using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class mrm1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_MatchResult_MatchResultId1",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_MatchResultId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_MatchResultId1",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "MatchResultId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "MatchResultId1",
                table: "Match");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "MatchResult",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchResult_Match_MatchId",
                table: "MatchResult");

            migrationBuilder.DropIndex(
                name: "IX_MatchResult_MatchId",
                table: "MatchResult");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "MatchResult");

            migrationBuilder.AddColumn<int>(
                name: "MatchResultId",
                table: "Match",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchResultId1",
                table: "Match",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchResultId",
                table: "Match",
                column: "MatchResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchResultId1",
                table: "Match",
                column: "MatchResultId1",
                unique: true,
                filter: "[MatchResultId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match",
                column: "MatchResultId",
                principalTable: "MatchResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_MatchResult_MatchResultId1",
                table: "Match",
                column: "MatchResultId1",
                principalTable: "MatchResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
