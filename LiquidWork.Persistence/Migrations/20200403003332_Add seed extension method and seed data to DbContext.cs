using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquidWork.Persistence.Migrations
{
    public partial class AddseedextensionmethodandseeddatatoDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Legajos",
                columns: new[] { "NumeroLegajo", "Apellido", "CUIL", "Categoria", "FechaIngreso", "Nombre" },
                values: new object[,]
                {
                    { 1, "Shakespeare", 20356568524L, "Auxiliar A", new DateTime(2012, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "William" },
                    { 2, "Picapiedra", 2035545524L, "Auxiliar B", new DateTime(2013, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro" },
                    { 3, "Perez", 2035545524L, "Auxiliar B", new DateTime(2013, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julio" },
                    { 4, "Ramirez", 2035545524L, "Auxiliar C", new DateTime(2014, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos" },
                    { 5, "Gonzalez", 2335545526L, "Auxiliar B", new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosa" },
                    { 6, "Perez", 2335532526L, "Auxiliar A", new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samanta" },
                    { 7, "Gomez", 2338745526L, "Auxiliar C", new DateTime(2018, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eugenia" },
                    { 8, "Fernandez", 2035545524L, "Auxiliar E", new DateTime(2010, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julian" },
                    { 9, "Smith", 2336645526L, "Auxiliar B", new DateTime(2009, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estela" },
                    { 10, "Candia", 2335555526L, "Auxiliar B", new DateTime(2011, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariana" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Legajos",
                keyColumn: "NumeroLegajo",
                keyValue: 10);
        }
    }
}
