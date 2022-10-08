using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class fkGSNT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NationalTeams_GroupsStage_GroupStageId",
                table: "NationalTeams");

            migrationBuilder.AlterColumn<int>(
                name: "GroupStageId",
                table: "NationalTeams",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_NationalTeams_GroupsStage_GroupStageId",
                table: "NationalTeams",
                column: "GroupStageId",
                principalTable: "GroupsStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NationalTeams_GroupsStage_GroupStageId",
                table: "NationalTeams");

            migrationBuilder.AlterColumn<int>(
                name: "GroupStageId",
                table: "NationalTeams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NationalTeams_GroupsStage_GroupStageId",
                table: "NationalTeams",
                column: "GroupStageId",
                principalTable: "GroupsStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
