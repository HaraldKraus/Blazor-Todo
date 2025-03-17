using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestBlazorAPP.Migrations
{
    /// <inheritdoc />
    public partial class GelöschtHinzugefügt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Geloescht",
                schema: "ToDo",
                table: "Aufgabe",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "ToDo",
                table: "Aufgabe",
                keyColumn: "Id",
                keyValue: 1,
                column: "Geloescht",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geloescht",
                schema: "ToDo",
                table: "Aufgabe");
        }
    }
}
