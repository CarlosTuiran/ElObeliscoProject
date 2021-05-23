using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdProveedor",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 22, 19, 57, 24, 883, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaRegistro", "IdProveedor" },
                values: new object[] { new DateTime(2021, 5, 22, 19, 57, 24, 879, DateTimeKind.Local).AddTicks(4812), "106583" });

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 22, 19, 57, 24, 883, DateTimeKind.Local).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 22, 19, 57, 24, 884, DateTimeKind.Local).AddTicks(486));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdProveedor",
                table: "Producto",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 20, 21, 15, 5, 948, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaRegistro", "IdProveedor" },
                values: new object[] { new DateTime(2021, 5, 20, 21, 15, 5, 945, DateTimeKind.Local).AddTicks(2426), 1 });

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 20, 21, 15, 5, 949, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 20, 21, 15, 5, 949, DateTimeKind.Local).AddTicks(2858));
        }
    }
}
