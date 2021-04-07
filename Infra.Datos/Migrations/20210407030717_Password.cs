using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class Password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DFactura",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFactura",
                value: new DateTime(2021, 4, 6, 22, 7, 16, 515, DateTimeKind.Local).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 4, 6, 22, 7, 16, 511, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "MFactura",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFactura", "FechaPago" },
                values: new object[] { new DateTime(2021, 4, 6, 22, 7, 16, 514, DateTimeKind.Local).AddTicks(300), new DateTime(2021, 4, 6, 22, 7, 16, 514, DateTimeKind.Local).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 4, 6, 22, 7, 16, 505, DateTimeKind.Local).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 4, 6, 22, 7, 16, 513, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 4, 6, 22, 7, 16, 513, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "EAAAAHDlgUkazfaO5QNj7D / gFmseTKDUliA11ginT5ElAN + V");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DFactura",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFactura",
                value: new DateTime(2021, 4, 6, 21, 47, 56, 713, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 4, 6, 21, 47, 56, 712, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "MFactura",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFactura", "FechaPago" },
                values: new object[] { new DateTime(2021, 4, 6, 21, 47, 56, 713, DateTimeKind.Local).AddTicks(864), new DateTime(2021, 4, 6, 21, 47, 56, 713, DateTimeKind.Local).AddTicks(2625) });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 4, 6, 21, 47, 56, 709, DateTimeKind.Local).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 4, 6, 21, 47, 56, 712, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 4, 6, 21, 47, 56, 712, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "raulh");
        }
    }
}
