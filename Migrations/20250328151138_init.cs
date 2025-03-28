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
                    Prioritaet = table.Column<int>(type: "int", nullable: false),
                    Geloescht = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aufgabe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bild",
                schema: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AufgabeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bild_Aufgabe_AufgabeId",
                        column: x => x.AufgabeId,
                        principalSchema: "ToDo",
                        principalTable: "Aufgabe",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "ToDo",
                table: "Aufgabe",
                columns: new[] { "Id", "Geloescht", "Name", "Prioritaet" },
                values: new object[] { 1, false, "Testaufgabe", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Bild_AufgabeId",
                schema: "ToDo",
                table: "Bild",
                column: "AufgabeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bild",
                schema: "ToDo");

            migrationBuilder.DropTable(
                name: "Aufgabe",
                schema: "ToDo");
        }
    }
}
