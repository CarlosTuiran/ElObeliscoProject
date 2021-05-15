using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class cantidaddouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Cantidad",
                table: "Inventario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "CantidadDigitada",
                table: "DFactura",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Cantidad",
                table: "DFactura",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 14, 21, 54, 2, 457, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Inventario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cantidad",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 5, 14, 21, 54, 2, 452, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 14, 21, 54, 2, 459, DateTimeKind.Local).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 14, 21, 54, 2, 459, DateTimeKind.Local).AddTicks(1247));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "Inventario",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "CantidadDigitada",
                table: "DFactura",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "DFactura",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 9, 21, 19, 26, 544, DateTimeKind.Local).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Inventario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cantidad",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 5, 9, 21, 19, 26, 527, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 9, 21, 19, 26, 546, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 9, 21, 19, 26, 546, DateTimeKind.Local).AddTicks(3199));
        }
    }
}
