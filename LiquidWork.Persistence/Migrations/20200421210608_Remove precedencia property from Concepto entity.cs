using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquidWork.Persistence.Migrations
{
    public partial class RemoveprecedenciapropertyfromConceptoentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precedencia",
                table: "Conceptos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Precedencia",
                table: "Conceptos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 11,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 12,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 13,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 14,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 15,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 16,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 17,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 18,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 19,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 20,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 21,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 22,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 23,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 24,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 25,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 26,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 27,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 28,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 29,
                column: "Precedencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Conceptos",
                keyColumn: "ConceptoId",
                keyValue: 30,
                column: "Precedencia",
                value: 1);
        }
    }
}
