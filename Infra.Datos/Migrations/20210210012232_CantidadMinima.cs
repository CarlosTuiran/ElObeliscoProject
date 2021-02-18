using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class CantidadMinima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadMinima",
                table: "Producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DFactura",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFactura",
                value: new DateTime(2021, 2, 9, 20, 22, 31, 200, DateTimeKind.Local).AddTicks(1382));

            migrationBuilder.UpdateData(
                table: "MFactura",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFactura", "FechaPago" },
                values: new object[] { new DateTime(2021, 2, 9, 20, 22, 31, 198, DateTimeKind.Local).AddTicks(2679), new DateTime(2021, 2, 9, 20, 22, 31, 198, DateTimeKind.Local).AddTicks(5556) });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 2, 9, 20, 22, 31, 192, DateTimeKind.Local).AddTicks(5983));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadMinima",
                table: "Producto");

            migrationBuilder.UpdateData(
                table: "DFactura",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFactura",
                value: new DateTime(2021, 1, 20, 22, 42, 35, 450, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "MFactura",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFactura", "FechaPago" },
                values: new object[] { new DateTime(2021, 1, 20, 22, 42, 35, 449, DateTimeKind.Local).AddTicks(8094), new DateTime(2021, 1, 20, 22, 42, 35, 449, DateTimeKind.Local).AddTicks(9841) });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 1, 20, 22, 42, 35, 445, DateTimeKind.Local).AddTicks(9136));
        }
    }
}
