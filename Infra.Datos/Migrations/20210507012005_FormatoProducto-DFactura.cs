using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class FormatoProductoDFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormatoProducto",
                table: "DFactura",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 6, 20, 20, 4, 772, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 5, 6, 20, 20, 4, 769, DateTimeKind.Local).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 6, 20, 20, 4, 773, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 6, 20, 20, 4, 773, DateTimeKind.Local).AddTicks(8754));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormatoProducto",
                table: "DFactura");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 6, 20, 3, 49, 209, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 5, 6, 20, 3, 49, 203, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 6, 20, 3, 49, 210, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 6, 20, 3, 49, 210, DateTimeKind.Local).AddTicks(9539));
        }
    }
}
