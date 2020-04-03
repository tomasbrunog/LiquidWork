using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquidWork.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Legajos",
                columns: table => new
                {
                    NumeroLegajo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    CUIL = table.Column<long>(nullable: false),
                    Categoria = table.Column<string>(maxLength: 50, nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legajos", x => x.NumeroLegajo);
                });

            migrationBuilder.CreateTable(
                name: "Liquidaciones",
                columns: table => new
                {
                    LiquidacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Periodo = table.Column<DateTime>(nullable: false),
                    TotalRemunerativo = table.Column<decimal>(nullable: false),
                    TotalNoRemunerativo = table.Column<decimal>(nullable: false),
                    TotalDeducciones = table.Column<decimal>(nullable: false),
                    Neto = table.Column<decimal>(nullable: false),
                    LegajoNumeroLegajo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidaciones", x => x.LiquidacionId);
                    table.ForeignKey(
                        name: "FK_Liquidaciones_Legajos_LegajoNumeroLegajo",
                        column: x => x.LegajoNumeroLegajo,
                        principalTable: "Legajos",
                        principalColumn: "NumeroLegajo",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Conceptos",
                columns: table => new
                {
                    ConceptoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreConcepto = table.Column<string>(nullable: true),
                    Monto = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<double>(nullable: false),
                    Precedencia = table.Column<int>(nullable: false),
                    TipoConcepto = table.Column<int>(nullable: false),
                    LiquidacionId = table.Column<int>(nullable: true),
                    LegajoNumeroLegajo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.ConceptoId);
                    table.ForeignKey(
                        name: "FK_Conceptos_Legajos_LegajoNumeroLegajo",
                        column: x => x.LegajoNumeroLegajo,
                        principalTable: "Legajos",
                        principalColumn: "NumeroLegajo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conceptos_Liquidaciones_LiquidacionId",
                        column: x => x.LiquidacionId,
                        principalTable: "Liquidaciones",
                        principalColumn: "LiquidacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conceptos_LegajoNumeroLegajo",
                table: "Conceptos",
                column: "LegajoNumeroLegajo");

            migrationBuilder.CreateIndex(
                name: "IX_Conceptos_LiquidacionId",
                table: "Conceptos",
                column: "LiquidacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidaciones_LegajoNumeroLegajo",
                table: "Liquidaciones",
                column: "LegajoNumeroLegajo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conceptos");

            migrationBuilder.DropTable(
                name: "Liquidaciones");

            migrationBuilder.DropTable(
                name: "Legajos");
        }
    }
}
