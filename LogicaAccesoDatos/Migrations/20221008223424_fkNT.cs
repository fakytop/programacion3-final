using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class fkNT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NationalTeams_GroupsStage_GroupStageId",
                table: "NationalTeams");

            migrationBuilder.AlterColumn<int>(
                name: "GroupStageId",
                table: "NationalTeams",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NationalTeams_GroupsStage_GroupStageId",
                table: "NationalTeams",
                column: "GroupStageId",
                principalTable: "GroupsStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_NationalTeams_GroupsStage_GroupStageId",
                table: "NationalTeams",
                column: "GroupStageId",
                principalTable: "GroupsStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
