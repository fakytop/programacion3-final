using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class groupStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISOAlfa3",
                table: "Countries",
                newName: "IsoAlfa3");

            migrationBuilder.AddColumn<int>(
                name: "GroupStageId",
                table: "NationalTeams",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupsStage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsStage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NationalTeams_GroupStageId",
                table: "NationalTeams",
                column: "GroupStageId");

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

            migrationBuilder.DropTable(
                name: "GroupsStage");

            migrationBuilder.DropIndex(
                name: "IX_NationalTeams_GroupStageId",
                table: "NationalTeams");

            migrationBuilder.DropColumn(
                name: "GroupStageId",
                table: "NationalTeams");

            migrationBuilder.RenameColumn(
                name: "IsoAlfa3",
                table: "Countries",
                newName: "ISOAlfa3");
        }
    }
}
