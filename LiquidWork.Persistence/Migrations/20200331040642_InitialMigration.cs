﻿using System;
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
                    LegajoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroLegajo = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    CUIL = table.Column<int>(nullable: false),
                    Categoria = table.Column<string>(maxLength: 50, nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legajos", x => x.LegajoId);
                });

            migrationBuilder.CreateTable(
                name: "Liquidaciones",
                columns: table => new
                {
                    LiquidacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Periodo = table.Column<DateTime>(nullable: false),
                    TotalRemunerativo = table.Column<decimal>(type: "decimal (9,2)", nullable: false),
                    TotalNoRemunerativo = table.Column<decimal>(type: "decimal (9,2)", nullable: false),
                    TotalDeducciones = table.Column<decimal>(type: "decimal (9,2)", nullable: false),
                    Neto = table.Column<decimal>(type: "decimal (9,2)", nullable: false),
                    LegajoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidaciones", x => x.LiquidacionId);
                    table.ForeignKey(
                        name: "FK_Liquidaciones_Legajos_LegajoId",
                        column: x => x.LegajoId,
                        principalTable: "Legajos",
                        principalColumn: "LegajoId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Conceptos",
                columns: table => new
                {
                    ConceptoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoConcepto = table.Column<int>(nullable: false),
                    Unidad = table.Column<double>(nullable: false),
                    Precedencia = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal (9,2)", nullable: false),
                    LiquidacionId = table.Column<int>(nullable: true),
                    LegajoId = table.Column<int>(nullable: true),
                    TipoConcepto = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.ConceptoId);
                    table.ForeignKey(
                        name: "FK_Conceptos_Legajos_LegajoId",
                        column: x => x.LegajoId,
                        principalTable: "Legajos",
                        principalColumn: "LegajoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conceptos_Liquidaciones_LiquidacionId",
                        column: x => x.LiquidacionId,
                        principalTable: "Liquidaciones",
                        principalColumn: "LiquidacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conceptos_LegajoId",
                table: "Conceptos",
                column: "LegajoId");

            migrationBuilder.CreateIndex(
                name: "IX_Conceptos_LiquidacionId",
                table: "Conceptos",
                column: "LiquidacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidaciones_LegajoId",
                table: "Liquidaciones",
                column: "LegajoId");
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
