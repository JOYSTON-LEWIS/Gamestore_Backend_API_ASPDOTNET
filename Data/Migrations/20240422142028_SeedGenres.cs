// TS-02:02:40-02:20:57: 
using Microsoft.EntityFrameworkCore.Migrations;

// TS-02:02:40-02:20:57: 
#nullable disable

// TS-02:02:40-02:20:57: 
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

// TS-02:02:40-02:20:57: 
namespace GameStore.Api.Data.Migrations
{
    /// <inheritdoc />
    // TS-02:02:40-02:20:57: 
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        // TS-02:02:40-02:20:57: 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // TS-02:02:40-02:20:57: 
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fighting" },
                    { 2, "RolePlaying" },
                    { 3, "Sports" },
                    { 4, "Racing" },
                    { 5, "Kids and Family" }
                });
        }

        /// <inheritdoc />
        // TS-02:02:40-02:20:57: 
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // TS-02:02:40-02:20:57: 
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            // TS-02:02:40-02:20:57: 
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            // TS-02:02:40-02:20:57: 
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            // TS-02:02:40-02:20:57: 
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            // TS-02:02:40-02:20:57: 
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
