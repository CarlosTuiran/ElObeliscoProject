using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class libroContable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrigenId",
                table: "LibroContable",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 6, 9, 21, 0, 2, 165, DateTimeKind.Local).AddTicks(5247));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 6, 9, 21, 0, 2, 162, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 6, 9, 21, 0, 2, 165, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 6, 9, 21, 0, 2, 165, DateTimeKind.Local).AddTicks(9972));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrigenId",
                table: "LibroContable",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 6, 7, 21, 44, 27, 541, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 6, 7, 21, 44, 27, 537, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 6, 7, 21, 44, 27, 542, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 6, 7, 21, 44, 27, 542, DateTimeKind.Local).AddTicks(1349));
        }
    }
}
