using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Modul4HW6.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inst = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_Id",
                        column: x => x.Id,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistSongs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "DateOfBirth", "Email", "Inst", "Name", "NumberOfPhone" },
                values: new object[,]
                {
                    { 1, new DateTime(2015, 7, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), "Email1@gmail.com", "https://inst1.com", "Artist1", "+123456789" },
                    { 2, new DateTime(1980, 6, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), "Email1@gmail.com", "https://inst2.com", "Artist2", "+789456123" },
                    { 3, new DateTime(1990, 5, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), "Email1@gmail.com", "https://inst3.com", "Artist3", "+456123789" },
                    { 4, new DateTime(2000, 4, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), "Email1@gmail.com", "https://inst4.com", "Artist4", "+123789456" },
                    { 5, new DateTime(2010, 3, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), "Email5@gmail.com", "https://inst5.com", "Artist5", "+654987321" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Title1" },
                    { 2, "Title2" },
                    { 3, "Title3" },
                    { 4, "Title4" },
                    { 5, "Title5" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "GenreId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 2.5m, 0, new DateTime(2015, 7, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Butter" },
                    { 2, 2.3m, 0, new DateTime(1976, 7, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Leave the door open" },
                    { 3, 2.0m, 0, new DateTime(2001, 7, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Kiss me more" },
                    { 4, 1.5m, 0, new DateTime(2014, 7, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Save your tears" },
                    { 5, 1.8m, 0, new DateTime(2020, 7, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "good 4 u" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSongs_ArtistId",
                table: "ArtistSongs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSongs_SongId",
                table: "ArtistSongs",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSongs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
