using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class CantidadDigitadaDFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadDigitada",
                table: "DFactura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 6, 20, 3, 49, 209, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 5, 6, 20, 3, 49, 203, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 6, 20, 3, 49, 210, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 6, 20, 3, 49, 210, DateTimeKind.Local).AddTicks(9539));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadDigitada",
                table: "DFactura");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 3, 21, 57, 3, 690, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 5, 3, 21, 57, 3, 682, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 3, 21, 57, 3, 690, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 3, 21, 57, 3, 691, DateTimeKind.Local).AddTicks(737));
        }
    }
}
