using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class MasEliminarEstados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Terceros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Producto",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DFactura",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFactura",
                value: new DateTime(2021, 2, 25, 20, 8, 48, 731, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "MFactura",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFactura", "FechaPago" },
                values: new object[] { new DateTime(2021, 2, 25, 20, 8, 48, 730, DateTimeKind.Local).AddTicks(8934), new DateTime(2021, 2, 25, 20, 8, 48, 731, DateTimeKind.Local).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 2, 25, 20, 8, 48, 725, DateTimeKind.Local).AddTicks(1047));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Producto");

            migrationBuilder.UpdateData(
                table: "DFactura",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFactura",
                value: new DateTime(2021, 2, 17, 21, 58, 24, 739, DateTimeKind.Local).AddTicks(182));

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
    }
}
