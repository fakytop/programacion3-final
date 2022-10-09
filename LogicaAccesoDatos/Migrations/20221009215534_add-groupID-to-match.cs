using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class addgroupIDtomatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Match",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Match_GroupID",
                table: "Match",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_GroupsStage_GroupID",
                table: "Match",
                column: "GroupID",
                principalTable: "GroupsStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_GroupsStage_GroupID",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_GroupID",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Match");
        }
    }
}
