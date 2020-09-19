using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class OnDeleteRestric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DFactura_MFactura_MfacturaId",
                table: "DFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Nomina_NominaId",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Liquidacion_Nomina_NominaId",
                table: "Liquidacion");

            migrationBuilder.DropForeignKey(
                name: "FK_MFactura_Empleado_EmpleadoId",
                table: "MFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_MFactura_Terceros_TercerosId",
                table: "MFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_MFactura_TipoMovimiento_TipoMovimientoId",
                table: "MFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoDFactura_DFactura_DFacturaId",
                table: "ProductoDFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoDFactura_Producto_ProductoId",
                table: "ProductoDFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_PromocionesDFactura_DFactura_DFacturaId",
                table: "PromocionesDFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empleado_EmpleadoId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_DFactura_MFactura_MfacturaId",
                table: "DFactura",
                column: "MfacturaId",
                principalTable: "MFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Nomina_NominaId",
                table: "Empleado",
                column: "NominaId",
                principalTable: "Nomina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Liquidacion_Nomina_NominaId",
                table: "Liquidacion",
                column: "NominaId",
                principalTable: "Nomina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MFactura_Empleado_EmpleadoId",
                table: "MFactura",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MFactura_Terceros_TercerosId",
                table: "MFactura",
                column: "TercerosId",
                principalTable: "Terceros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MFactura_TipoMovimiento_TipoMovimientoId",
                table: "MFactura",
                column: "TipoMovimientoId",
                principalTable: "TipoMovimiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoDFactura_DFactura_DFacturaId",
                table: "ProductoDFactura",
                column: "DFacturaId",
                principalTable: "DFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoDFactura_Producto_ProductoId",
                table: "ProductoDFactura",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PromocionesDFactura_DFactura_DFacturaId",
                table: "PromocionesDFactura",
                column: "DFacturaId",
                principalTable: "DFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empleado_EmpleadoId",
                table: "Usuario",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DFactura_MFactura_MfacturaId",
                table: "DFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Nomina_NominaId",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Liquidacion_Nomina_NominaId",
                table: "Liquidacion");

            migrationBuilder.DropForeignKey(
                name: "FK_MFactura_Empleado_EmpleadoId",
                table: "MFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_MFactura_Terceros_TercerosId",
                table: "MFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_MFactura_TipoMovimiento_TipoMovimientoId",
                table: "MFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoDFactura_DFactura_DFacturaId",
                table: "ProductoDFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoDFactura_Producto_ProductoId",
                table: "ProductoDFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_PromocionesDFactura_DFactura_DFacturaId",
                table: "PromocionesDFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empleado_EmpleadoId",
                table: "Usuario");

            migrationBuilder.UpdateData(
                table: "Liquidacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaPago",
                value: new DateTime(2020, 9, 19, 16, 2, 52, 513, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2020, 9, 19, 16, 2, 52, 503, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.AddForeignKey(
                name: "FK_DFactura_MFactura_MfacturaId",
                table: "DFactura",
                column: "MfacturaId",
                principalTable: "MFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Nomina_NominaId",
                table: "Empleado",
                column: "NominaId",
                principalTable: "Nomina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Liquidacion_Nomina_NominaId",
                table: "Liquidacion",
                column: "NominaId",
                principalTable: "Nomina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MFactura_Empleado_EmpleadoId",
                table: "MFactura",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MFactura_Terceros_TercerosId",
                table: "MFactura",
                column: "TercerosId",
                principalTable: "Terceros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MFactura_TipoMovimiento_TipoMovimientoId",
                table: "MFactura",
                column: "TipoMovimientoId",
                principalTable: "TipoMovimiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoDFactura_DFactura_DFacturaId",
                table: "ProductoDFactura",
                column: "DFacturaId",
                principalTable: "DFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoDFactura_Producto_ProductoId",
                table: "ProductoDFactura",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromocionesDFactura_DFactura_DFacturaId",
                table: "PromocionesDFactura",
                column: "DFacturaId",
                principalTable: "DFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empleado_EmpleadoId",
                table: "Usuario",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
