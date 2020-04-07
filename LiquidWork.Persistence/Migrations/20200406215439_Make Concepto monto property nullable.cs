using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquidWork.Persistence.Migrations
{
    public partial class MakeConceptomontopropertynullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Conceptos",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Conceptos",
                columns: new[] { "ConceptoId", "Cantidad", "CodigoConcepto", "LegajoNumeroLegajo", "LiquidacionId", "Monto", "NombreConcepto", "Precedencia", "TipoConcepto" },
                values: new object[,]
                {
                    { 30, 1.0, 101, null, null, 35500m, "Sueldo basico", 1, 0 },
                    { 27, 11.0, 201, null, null, null, "Jubilacion", 1, 2 },
                    { 26, 11.0, 201, null, null, null, "Jubilacion", 1, 2 },
                    { 25, 11.0, 201, null, null, null, "Jubilacion", 1, 2 },
                    { 24, 11.0, 201, null, null, null, "Jubilacion", 1, 2 },
                    { 23, 11.0, 201, null, null, null, "Jubilacion", 1, 2 },
                    { 22, 11.0, 201, null, null, null, "Jubilacion", 1, 2 },
                    { 21, 11.0, 201, null, null, null, "Jubilacion", 1, 2 },
                    { 20, 11.0, 201, null, null, null, "Jubilacion", 1, 2 },
                    { 19, 1.0, 101, null, null, 44600m, "Sueldo basico", 1, 0 },
                    { 18, 1.0, 101, null, null, 33900m, "Sueldo basico", 1, 0 },
                    { 17, 1.0, 101, null, null, 44000m, "Sueldo basico", 1, 0 },
                    { 16, 1.0, 101, null, null, 68600m, "Sueldo basico", 1, 0 },
                    { 15, 1.0, 101, null, null, 35500m, "Sueldo basico", 1, 0 },
                    { 14, 1.0, 101, null, null, 43000m, "Sueldo basico", 1, 0 },
                    { 13, 1.0, 101, null, null, 80500m, "Sueldo basico", 1, 0 },
                    { 12, 1.0, 101, null, null, 37000m, "Sueldo basico", 1, 0 },
                    { 11, 1.0, 101, null, null, 35500m, "Sueldo basico", 1, 0 },
                    { 28, 11.0, 201, null, null, null, "Jubilacion", 1, 2 },
                    { 29, 11.0, 201, null, null, null, "Jubilacion", 1, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Conceptos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
