using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class Prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEmpleado",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Nit",
                table: "MFactura");

            migrationBuilder.DropColumn(
                name: "idEmpleado",
                table: "MFactura");

            migrationBuilder.DropColumn(
                name: "idMovimiento",
                table: "MFactura");

            migrationBuilder.DropColumn(
                name: "IdNomina",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "idMfactura",
                table: "DFactura");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventarioId",
                table: "Producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FechaPago",
                table: "MFactura",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "FechaFactura",
                table: "MFactura",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "MFactura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TercerosId",
                table: "MFactura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoMovimientoId",
                table: "MFactura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NominaId",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NominaId",
                table: "Empleado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "idPromocion",
                table: "DFactura",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FechaFactura",
                table: "DFactura",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "MfacturaId",
                table: "DFactura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductoDFactura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: false),
                    DFacturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoDFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoDFactura_DFactura_DFacturaId",
                        column: x => x.DFacturaId,
                        principalTable: "DFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoDFactura_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromocionesDFactura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromocionesId = table.Column<int>(nullable: false),
                    DFacturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocionesDFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromocionesDFactura_DFactura_DFacturaId",
                        column: x => x.DFacturaId,
                        principalTable: "DFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tiempo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Año = table.Column<int>(nullable: false),
                    Mes = table.Column<int>(nullable: false),
                    Dia = table.Column<int>(nullable: false),
                    DiaDelAño = table.Column<int>(nullable: false),
                    SemanaDelAño = table.Column<int>(nullable: false),
                    Trimestre = table.Column<int>(nullable: false),
                    Semestre = table.Column<int>(nullable: false),
                    NombreMes = table.Column<string>(nullable: true),
                    NombreMesCorto = table.Column<string>(nullable: true),
                    NombreDia = table.Column<string>(nullable: true),
                    NombreDiaCorto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiempo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpleadoId",
                table: "Usuario",
                column: "EmpleadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_InventarioId",
                table: "Producto",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MFactura_EmpleadoId",
                table: "MFactura",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MFactura_TercerosId",
                table: "MFactura",
                column: "TercerosId");

            migrationBuilder.CreateIndex(
                name: "IX_MFactura_TipoMovimientoId",
                table: "MFactura",
                column: "TipoMovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidacion_NominaId",
                table: "Liquidacion",
                column: "NominaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_NominaId",
                table: "Empleado",
                column: "NominaId");

            migrationBuilder.CreateIndex(
                name: "IX_DFactura_MfacturaId",
                table: "DFactura",
                column: "MfacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoDFactura_DFacturaId",
                table: "ProductoDFactura",
                column: "DFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoDFactura_ProductoId",
                table: "ProductoDFactura",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionesDFactura_DFacturaId",
                table: "PromocionesDFactura",
                column: "DFacturaId");

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
                name: "FK_Producto_Inventario_InventarioId",
                table: "Producto",
                column: "InventarioId",
                principalTable: "Inventario",
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
                name: "FK_Producto_Inventario_InventarioId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empleado_EmpleadoId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "ProductoDFactura");

            migrationBuilder.DropTable(
                name: "PromocionesDFactura");

            migrationBuilder.DropTable(
                name: "Tiempo");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EmpleadoId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Producto_InventarioId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_MFactura_EmpleadoId",
                table: "MFactura");

            migrationBuilder.DropIndex(
                name: "IX_MFactura_TercerosId",
                table: "MFactura");

            migrationBuilder.DropIndex(
                name: "IX_MFactura_TipoMovimientoId",
                table: "MFactura");

            migrationBuilder.DropIndex(
                name: "IX_Liquidacion_NominaId",
                table: "Liquidacion");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_NominaId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_DFactura_MfacturaId",
                table: "DFactura");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "MFactura");

            migrationBuilder.DropColumn(
                name: "TercerosId",
                table: "MFactura");

            migrationBuilder.DropColumn(
                name: "TipoMovimientoId",
                table: "MFactura");

            migrationBuilder.DropColumn(
                name: "NominaId",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "NominaId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "MfacturaId",
                table: "DFactura");

            migrationBuilder.AddColumn<int>(
                name: "IdEmpleado",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPago",
                table: "MFactura",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFactura",
                table: "MFactura",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Nit",
                table: "MFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idEmpleado",
                table: "MFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idMovimiento",
                table: "MFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdNomina",
                table: "Liquidacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "idPromocion",
                table: "DFactura",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFactura",
                table: "DFactura",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "idMfactura",
                table: "DFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
