using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITFCode.Lexicon.Domain.Migrations.LexiconDb
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "LithuanianWord",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "OriginalLanguage",
                table: "LithuanianWord",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalLanguage",
                table: "LithuanianWord");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LithuanianWord",
                newName: "Value");
        }
    }
}
