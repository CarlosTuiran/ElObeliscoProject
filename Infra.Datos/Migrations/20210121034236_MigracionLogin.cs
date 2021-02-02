using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class MigracionLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Usuario",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rol",
                value: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DFactura",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFactura",
                value: new DateTime(2020, 12, 2, 0, 38, 30, 251, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "MFactura",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFactura", "FechaPago" },
                values: new object[] { new DateTime(2020, 12, 2, 0, 38, 30, 250, DateTimeKind.Local).AddTicks(1068), new DateTime(2020, 12, 2, 0, 38, 30, 250, DateTimeKind.Local).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2020, 12, 2, 0, 38, 30, 243, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tipo",
                value: "Admin");
        }
    }
}
