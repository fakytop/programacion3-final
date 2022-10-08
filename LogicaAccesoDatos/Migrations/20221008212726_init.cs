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
                    Match_Date = table.Column<DateTime>(nullable: true)
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
                        name: "FK_Match_NationalTeams_HomeId",
                        column: x => x.HomeId,
                        principalTable: "NationalTeams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: true),
                    MatchId = table.Column<int>(nullable: false),
                    Goals_Home = table.Column<int>(nullable: true),
                    Goals_Away = table.Column<int>(nullable: true),
                    Yellow_Cards_Home = table.Column<int>(nullable: true),
                    Yellow_Cards_Away = table.Column<int>(nullable: true),
                    Red_Cards_Home = table.Column<int>(nullable: true),
                    Red_Cards_Away = table.Column<int>(nullable: true),
                    Red_Direct_Card_Home = table.Column<int>(nullable: true),
                    Red_Direct_Card_Away = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchResult_GroupsStage_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupsStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchResult_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayId",
                table: "Match",
                column: "AwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeId",
                table: "Match",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResult_GroupId",
                table: "MatchResult",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResult_MatchId",
                table: "MatchResult",
                column: "MatchId",
                unique: true);

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
                name: "MatchResult");

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
