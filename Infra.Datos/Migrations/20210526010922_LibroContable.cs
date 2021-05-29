using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class LibroContable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IVA",
                table: "Producto");

            migrationBuilder.AddColumn<int>(
                name: "CuentaDevolucion",
                table: "Producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CuentaIngreso",
                table: "Producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImpuestosProducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<string>(nullable: true),
                    IdImpuesto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpuestosProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibroContable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Debe = table.Column<double>(nullable: true),
                    Haber = table.Column<double>(nullable: true),
                    OrigenId = table.Column<int>(nullable: false),
                    OrigenTipo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroContable", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 25, 20, 9, 21, 665, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 5, 25, 20, 9, 21, 660, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 25, 20, 9, 21, 667, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 25, 20, 9, 21, 667, DateTimeKind.Local).AddTicks(9123));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImpuestosProducto");

            migrationBuilder.DropTable(
                name: "LibroContable");

            migrationBuilder.DropColumn(
                name: "CuentaDevolucion",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "CuentaIngreso",
                table: "Producto");

            migrationBuilder.AddColumn<double>(
                name: "IVA",
                table: "Producto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 22, 22, 13, 21, 29, DateTimeKind.Local).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaRegistro", "IVA" },
                values: new object[] { new DateTime(2021, 5, 22, 22, 13, 21, 26, DateTimeKind.Local).AddTicks(4582), 0.29999999999999999 });

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 22, 22, 13, 21, 30, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 22, 22, 13, 21, 30, DateTimeKind.Local).AddTicks(4216));
        }
    }
}
