using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroPrestamo.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPersona = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPrestamo = table.Column<int>(nullable: false),
                    Monto = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    ConceptoPrestamo = table.Column<string>(nullable: true),
                    FechaPrestamo = table.Column<DateTime>(nullable: false),
                    Historial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPersona);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
