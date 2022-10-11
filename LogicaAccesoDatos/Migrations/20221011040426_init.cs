using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsoAlfa3 = table.Column<string>(nullable: true),
                    GDP = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Population = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "NationalTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email_Value = table.Column<string>(nullable: true),
                    Bettors = table.Column<int>(nullable: true),
                    GroupStageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NationalTeams_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NationalTeams_GroupsStage_GroupStageId",
                        column: x => x.GroupStageId,
                        principalTable: "GroupsStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeId = table.Column<int>(nullable: false),
                    AwayId = table.Column<int>(nullable: false),
                    Goals_Home = table.Column<int>(nullable: true),
                    YellowCards_Home = table.Column<int>(nullable: true),
                    RedCards_Home = table.Column<int>(nullable: true),
                    Direct_RedCards_Home = table.Column<int>(nullable: true),
                    Goals_Away = table.Column<int>(nullable: true),
                    YellowCards_Away = table.Column<int>(nullable: true),
                    RedCards_Away = table.Column<int>(nullable: true),
                    Direct_RedCards_Away = table.Column<int>(nullable: true),
                    Match_Date = table.Column<DateTime>(nullable: true),
                    GroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_NationalTeams_AwayId",
                        column: x => x.AwayId,
                        principalTable: "NationalTeams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_GroupsStage_GroupID",
                        column: x => x.GroupID,
                        principalTable: "GroupsStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_NationalTeams_HomeId",
                        column: x => x.HomeId,
                        principalTable: "NationalTeams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayId",
                table: "Match",
                column: "AwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_GroupID",
                table: "Match",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeId",
                table: "Match",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_NationalTeams_CountryId",
                table: "NationalTeams",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_NationalTeams_GroupStageId",
                table: "NationalTeams",
                column: "GroupStageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "NationalTeams");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "GroupsStage");
        }
    }
}
