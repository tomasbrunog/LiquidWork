using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquidWork.Persistence.Migrations
{
    public partial class AddprivatesettertoConceptopropertyCodigoConceptoTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoConcepto",
                table: "Conceptos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 2,
                column: "CUIL",
                value: 20355455244L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 3,
                column: "CUIL",
                value: 20355455524L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 4,
                column: "CUIL",
                value: 20355485524L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 5,
                column: "CUIL",
                value: 23355455526L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 6,
                column: "CUIL",
                value: 23355342526L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 8,
                column: "CUIL",
                value: 20235545524L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 9,
                column: "CUIL",
                value: 23366845526L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 10,
                column: "CUIL",
                value: 23335555526L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoConcepto",
                table: "Conceptos");

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 2,
                column: "CUIL",
                value: 2035545524L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 3,
                column: "CUIL",
                value: 2035545524L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 4,
                column: "CUIL",
                value: 2035545524L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 5,
                column: "CUIL",
                value: 2335545526L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 6,
                column: "CUIL",
                value: 2335532526L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 8,
                column: "CUIL",
                value: 2035545524L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 9,
                column: "CUIL",
                value: 2336645526L);

            migrationBuilder.UpdateData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 10,
                column: "CUIL",
                value: 2335555526L);
        }
    }
}
