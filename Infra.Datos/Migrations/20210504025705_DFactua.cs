using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class DFactua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idDFactura",
                table: "DFactura");

            migrationBuilder.AddColumn<double>(
                name: "IVA",
                table: "DFactura",
                nullable: false,
                defaultValue: 0.0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IVA",
                table: "DFactura");

            migrationBuilder.AddColumn<int>(
                name: "idDFactura",
                table: "DFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 4, 29, 21, 14, 46, 953, DateTimeKind.Local).AddTicks(1289));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 4, 29, 21, 14, 46, 948, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 4, 29, 21, 14, 46, 954, DateTimeKind.Local).AddTicks(427));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 4, 29, 21, 14, 46, 954, DateTimeKind.Local).AddTicks(1543));
        }
    }
}
