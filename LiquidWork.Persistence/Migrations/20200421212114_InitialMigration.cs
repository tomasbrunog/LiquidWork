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
                    TotalRemunerativo = table.Column<decimal>(type: "decimal (18,2)", nullable: true),
                    TotalNoRemunerativo = table.Column<decimal>(type: "decimal (18,2)", nullable: true),
                    TotalDeducciones = table.Column<decimal>(type: "decimal (18,2)", nullable: true),
                    Neto = table.Column<decimal>(type: "decimal (18,2)", nullable: true),
                    NumeroLegajo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidaciones", x => x.LiquidacionId);
                    table.ForeignKey(
                        name: "FK_Liquidaciones_Legajos_NumeroLegajo",
                        column: x => x.NumeroLegajo,
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
                    CodigoConcepto = table.Column<int>(nullable: false),
                    NombreConcepto = table.Column<string>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal (18,2)", nullable: false),
                    Cantidad = table.Column<double>(nullable: true),
                    TipoConcepto = table.Column<int>(nullable: false),
                    LiquidacionId = table.Column<int>(nullable: true),
                    NumeroLegajo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.ConceptoId);
                    table.ForeignKey(
                        name: "FK_Conceptos_Liquidaciones_LiquidacionId",
                        column: x => x.LiquidacionId,
                        principalTable: "Liquidaciones",
                        principalColumn: "LiquidacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conceptos_Legajos_NumeroLegajo",
                        column: x => x.NumeroLegajo,
                        principalTable: "Legajos",
                        principalColumn: "NumeroLegajo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Legajos",
                columns: new[] { "NumeroLegajo", "Apellido", "CUIL", "Categoria", "FechaIngreso", "Nombre" },
                values: new object[,]
                {
                    { 1, "Shakespeare", 20356568524L, "Auxiliar A", new DateTime(2012, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "William" },
                    { 2, "Picapiedra", 20355455244L, "Auxiliar B", new DateTime(2013, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro" },
                    { 3, "Perez", 20355455524L, "Auxiliar B", new DateTime(2013, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julio" },
                    { 4, "Ramirez", 20355485524L, "Auxiliar C", new DateTime(2014, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos" },
                    { 5, "Gonzalez", 23355455526L, "Auxiliar B", new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosa" },
                    { 6, "Perez", 23355342526L, "Auxiliar A", new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samanta" },
                    { 7, "Gomez", 23387455263L, "Auxiliar C", new DateTime(2018, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eugenia" },
                    { 8, "Fernandez", 20235545524L, "Auxiliar E", new DateTime(2010, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julian" },
                    { 9, "Smith", 23366845526L, "Auxiliar B", new DateTime(2009, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estela" },
                    { 10, "Candia", 23335555526L, "Auxiliar B", new DateTime(2011, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariana" }
                });

            migrationBuilder.InsertData(
                table: "Conceptos",
                columns: new[] { "ConceptoId", "Cantidad", "CodigoConcepto", "LiquidacionId", "Monto", "NombreConcepto", "NumeroLegajo", "TipoConcepto" },
                values: new object[,]
                {
                    { 30, 1.0, 101, null, 35500m, "Sueldo basico", 1, 0 },
                    { 28, 11.0, 201, null, 0m, "Jubilacion", 9, 2 },
                    { 18, 1.0, 101, null, 33900m, "Sueldo basico", 9, 0 },
                    { 27, 11.0, 201, null, 0m, "Jubilacion", 8, 2 },
                    { 17, 1.0, 101, null, 44000m, "Sueldo basico", 8, 0 },
                    { 26, 11.0, 201, null, 0m, "Jubilacion", 7, 2 },
                    { 16, 1.0, 101, null, 68600m, "Sueldo basico", 7, 0 },
                    { 25, 11.0, 201, null, 0m, "Jubilacion", 6, 2 },
                    { 15, 1.0, 101, null, 35500m, "Sueldo basico", 6, 0 },
                    { 24, 11.0, 201, null, 0m, "Jubilacion", 5, 2 },
                    { 14, 1.0, 101, null, 43000m, "Sueldo basico", 5, 0 },
                    { 23, 11.0, 201, null, 0m, "Jubilacion", 4, 2 },
                    { 13, 1.0, 101, null, 80500m, "Sueldo basico", 4, 0 },
                    { 22, 11.0, 201, null, 0m, "Jubilacion", 3, 2 },
                    { 12, 1.0, 101, null, 37000m, "Sueldo basico", 3, 0 },
                    { 21, 11.0, 201, null, 0m, "Jubilacion", 2, 2 },
                    { 11, 1.0, 101, null, 35500m, "Sueldo basico", 2, 0 },
                    { 20, 11.0, 201, null, 0m, "Jubilacion", 1, 2 },
                    { 19, 1.0, 101, null, 44600m, "Sueldo basico", 10, 0 },
                    { 29, 11.0, 201, null, 0m, "Jubilacion", 10, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conceptos_LiquidacionId",
                table: "Conceptos",
                column: "LiquidacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Conceptos_NumeroLegajo",
                table: "Conceptos",
                column: "NumeroLegajo");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidaciones_NumeroLegajo",
                table: "Liquidaciones",
                column: "NumeroLegajo");
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
