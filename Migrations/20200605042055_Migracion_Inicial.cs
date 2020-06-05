using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgramaPrestamos.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Historial = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPersona = table.Column<int>(nullable: false),
                    Monto = table.Column<double>(nullable: false),
                    ConceptoPrestamo = table.Column<string>(nullable: true),
                    FechaPrestamo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPrestamo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
