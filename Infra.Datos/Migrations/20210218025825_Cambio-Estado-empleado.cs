using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class CambioEstadoempleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Empleado",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DFactura",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFactura",
                value: new DateTime(2021, 2, 17, 21, 58, 24, 739, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "Estado",
                value: "Activo");

            migrationBuilder.UpdateData(
                table: "MFactura",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFactura", "FechaPago" },
                values: new object[] { new DateTime(2021, 2, 17, 21, 58, 24, 738, DateTimeKind.Local).AddTicks(3365), new DateTime(2021, 2, 17, 21, 58, 24, 738, DateTimeKind.Local).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 2, 17, 21, 58, 24, 734, DateTimeKind.Local).AddTicks(2713));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Empleado");

            migrationBuilder.UpdateData(
                table: "DFactura",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFactura",
                value: new DateTime(2021, 2, 17, 21, 33, 6, 925, DateTimeKind.Local).AddTicks(9212));

            migrationBuilder.UpdateData(
                table: "MFactura",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFactura", "FechaPago" },
                values: new object[] { new DateTime(2021, 2, 17, 21, 33, 6, 924, DateTimeKind.Local).AddTicks(9118), new DateTime(2021, 2, 17, 21, 33, 6, 925, DateTimeKind.Local).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 2, 17, 21, 33, 6, 918, DateTimeKind.Local).AddTicks(8748));
        }
    }
}
