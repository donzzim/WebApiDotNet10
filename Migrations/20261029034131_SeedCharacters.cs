using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoGameCharacterApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedCharacters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Game", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "Super Mario Bros.", "Mario", "Hero" },
                    { 2, "The Legend of Zelda.", "Link", "Hero" },
                    { 3, "Super Mario Bros.", "Bowser", "Villain" },
                    { 4, "The Legend of Zelda.", "Zelda", "Princess" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
