using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquidWork.Persistence.Migrations
{
    public partial class ChangeLiquidaciondecimalpropertiestonullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalRemunerativo",
                table: "Liquidaciones",
                type: "decimal (18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalNoRemunerativo",
                table: "Liquidaciones",
                type: "decimal (18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDeducciones",
                table: "Liquidaciones",
                type: "decimal (18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Neto",
                table: "Liquidaciones",
                type: "decimal (18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalRemunerativo",
                table: "Liquidaciones",
                type: "decimal (18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalNoRemunerativo",
                table: "Liquidaciones",
                type: "decimal (18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDeducciones",
                table: "Liquidaciones",
                type: "decimal (18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Neto",
                table: "Liquidaciones",
                type: "decimal (18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2)",
                oldNullable: true);
        }
    }
}
