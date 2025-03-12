using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestBlazorAPP.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ToDo");

            migrationBuilder.CreateTable(
                name: "Aufgabe",
                schema: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prioritaet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aufgabe", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ToDo",
                table: "Aufgabe",
                columns: new[] { "Id", "Name", "Prioritaet" },
                values: new object[] { 1, "Testaufgabe", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aufgabe",
                schema: "ToDo");
        }
    }
}
