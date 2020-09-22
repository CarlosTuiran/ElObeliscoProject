using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class UsuarioTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Usuario",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Liquidacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaPago",
                value: new DateTime(2020, 9, 20, 13, 27, 48, 961, DateTimeKind.Local).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2020, 9, 20, 13, 27, 48, 931, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tipo",
                value: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuario");

            migrationBuilder.UpdateData(
                table: "Liquidacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaPago",
                value: new DateTime(2020, 9, 19, 16, 5, 13, 281, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2020, 9, 19, 16, 5, 13, 269, DateTimeKind.Local).AddTicks(5618));
        }
    }
}
