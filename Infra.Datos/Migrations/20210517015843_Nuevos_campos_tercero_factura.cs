using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class Nuevos_campos_tercero_factura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Terceros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Terceros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "MFactura",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "MFactura",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 16, 20, 58, 41, 701, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 5, 16, 20, 58, 41, 690, DateTimeKind.Local).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 16, 20, 58, 41, 703, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 16, 20, 58, 41, 703, DateTimeKind.Local).AddTicks(5530));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "MFactura");

            migrationBuilder.DropColumn(
                name: "Serial",
                table: "MFactura");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 14, 21, 54, 2, 457, DateTimeKind.Local).AddTicks(9163));

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
    }
}
