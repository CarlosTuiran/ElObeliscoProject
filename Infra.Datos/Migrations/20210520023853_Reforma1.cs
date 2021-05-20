using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class Reforma1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nit",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Producto");

            migrationBuilder.AddColumn<string>(
                name: "ActividadEconomica",
                table: "Terceros",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AutoRetenedor",
                table: "Terceros",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Extranjero",
                table: "Terceros",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
                table: "Terceros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsabilidadFiscal",
                table: "Terceros",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ResponsableIva",
                table: "Terceros",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TipoId",
                table: "Terceros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoPersona",
                table: "Terceros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMarca",
                table: "Producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProveedor",
                table: "Producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 19, 21, 38, 51, 195, DateTimeKind.Local).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaRegistro", "IdCategoria", "IdMarca", "IdProveedor" },
                values: new object[] { new DateTime(2021, 5, 19, 21, 38, 51, 189, DateTimeKind.Local).AddTicks(3347), 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCumple", "Identificacion" },
                values: new object[] { new DateTime(2021, 5, 19, 21, 38, 51, 197, DateTimeKind.Local).AddTicks(16), "106583" });

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCumple", "Identificacion" },
                values: new object[] { new DateTime(2021, 5, 19, 21, 38, 51, 197, DateTimeKind.Local).AddTicks(1184), "10653434" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropColumn(
                name: "ActividadEconomica",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "AutoRetenedor",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "Extranjero",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "ResponsabilidadFiscal",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "ResponsableIva",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "TipoPersona",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdProveedor",
                table: "Producto");

            migrationBuilder.AddColumn<string>(
                name: "Nit",
                table: "Terceros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 16, 20, 58, 41, 701, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaRegistro", "Marca" },
                values: new object[] { new DateTime(2021, 5, 16, 20, 58, 41, 690, DateTimeKind.Local).AddTicks(8415), "Ferres" });

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCumple", "Nit" },
                values: new object[] { new DateTime(2021, 5, 16, 20, 58, 41, 703, DateTimeKind.Local).AddTicks(3983), "106583" });

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCumple", "Nit" },
                values: new object[] { new DateTime(2021, 5, 16, 20, 58, 41, 703, DateTimeKind.Local).AddTicks(5530), "10653434" });
        }
    }
}
