using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestBlazorAPP.Migrations
{
    /// <inheritdoc />
    public partial class addedDefaultAufgabe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "ToDo",
                table: "Aufgabe",
                columns: new[] { "Id", "Name", "Prioritaet" },
                values: new object[] { 1, "Testaufgabe", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ToDo",
                table: "Aufgabe",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
