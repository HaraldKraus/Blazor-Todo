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
                name: "Bild",
                schema: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bild", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aufgabe",
                schema: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prioritaet = table.Column<int>(type: "int", nullable: false),
                    Geloescht = table.Column<bool>(type: "bit", nullable: false),
                    BildId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aufgabe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aufgabe_Bild_BildId",
                        column: x => x.BildId,
                        principalSchema: "ToDo",
                        principalTable: "Bild",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "ToDo",
                table: "Aufgabe",
                columns: new[] { "Id", "BildId", "Geloescht", "Name", "Prioritaet" },
                values: new object[] { 1, null, false, "Testaufgabe", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Aufgabe_BildId",
                schema: "ToDo",
                table: "Aufgabe",
                column: "BildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aufgabe",
                schema: "ToDo");

            migrationBuilder.DropTable(
                name: "Bild",
                schema: "ToDo");
        }
    }
}
