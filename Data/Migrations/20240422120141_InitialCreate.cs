// TS-02:02:40-02:20:57: 
using System;
// TS-02:02:40-02:20:57: 
using Microsoft.EntityFrameworkCore.Migrations;

// TS-02:02:40-02:20:57: 
#nullable disable

// TS-02:02:40-02:20:57: 
namespace GameStore.Api.Data.Migrations
{
    /// <inheritdoc />
    // TS-02:02:40-02:20:57: 
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        // TS-02:02:40-02:20:57: 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // TS-02:02:40-02:20:57: 
            migrationBuilder.CreateTable(
                // TS-02:02:40-02:20:57: name of table
                name: "Genres",
                // TS-02:02:40-02:20:57: columns of table
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    // TS-02:02:40-02:20:57: primary key for genres
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            // TS-02:02:40-02:20:57: 
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    // TS-02:02:40-02:20:57: ID autoincremental
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    // TS-02:02:40-02:20:57: constraints
                    table.PrimaryKey("PK_Games", x => x.Id);
                    // TS-02:02:40-02:20:57: relates or linking
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // TS-02:02:40-02:20:57: 
            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");
        }

        /// <inheritdoc />
        // TS-02:02:40-02:20:57: 
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // TS-02:02:40-02:20:57: 
            // TS-02:02:40-02:20:57: previous version of database it will drop the 
            // TS-02:02:40-02:20:57: games and genres table in this order
            // TS-02:02:40-02:20:57: next lets execute this migration into the database
            migrationBuilder.DropTable(
                name: "Games");

            // TS-02:02:40-02:20:57:     
            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
