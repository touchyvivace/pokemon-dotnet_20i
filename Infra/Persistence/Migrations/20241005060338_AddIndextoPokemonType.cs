using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIndextoPokemonType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PokemonType",
                table: "Pokemons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_PokemonType",
                table: "Pokemons",
                column: "PokemonType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pokemons_PokemonType",
                table: "Pokemons");

            migrationBuilder.AlterColumn<string>(
                name: "PokemonType",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
