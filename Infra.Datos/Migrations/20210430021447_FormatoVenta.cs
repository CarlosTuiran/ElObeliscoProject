using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class FormatoVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpleado = table.Column<int>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormatoVenta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Abreviacion = table.Column<string>(nullable: true),
                    Metrica = table.Column<string>(nullable: true),
                    FactorConversion = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatoVenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Bodega = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nomina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNomina = table.Column<string>(nullable: true),
                    IdEmpleado = table.Column<int>(nullable: false),
                    DiasTrabajados = table.Column<int>(nullable: false),
                    HorasExtras = table.Column<int>(nullable: false),
                    SalarioBase = table.Column<double>(nullable: false),
                    SubTransporte = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terceros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    TipoTercero = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    FechaCumple = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terceros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tiempo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFecha = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Dia_Semana = table.Column<int>(nullable: false),
                    Dia_Mes = table.Column<int>(nullable: false),
                    Dia_Anio = table.Column<int>(nullable: false),
                    Semana_Anio = table.Column<int>(nullable: false),
                    Mes_Anio = table.Column<int>(nullable: false),
                    Cuatrimestre_Anio = table.Column<int>(nullable: false),
                    Semestre_Anio = table.Column<int>(nullable: false),
                    Anio = table.Column<string>(nullable: true),
                    Anio_Semana = table.Column<string>(nullable: true),
                    Anio_Mes = table.Column<string>(nullable: true),
                    Anio_Cuatrimestre = table.Column<string>(nullable: true),
                    Anio_Semestre = table.Column<string>(nullable: true),
                    Dia_Semana_Descripcion = table.Column<string>(nullable: true),
                    Mes_Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiempo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMovimiento = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TotalLiquidacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(nullable: false),
                    Anio = table.Column<int>(nullable: false),
                    ValorTotalNomina = table.Column<double>(nullable: false),
                    Sena = table.Column<double>(nullable: false),
                    Icbf = table.Column<double>(nullable: false),
                    Comfacesar = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    NominaId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalLiquidacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<int>(nullable: false),
                    Rol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FormatoVenta = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Fabrica = table.Column<string>(nullable: true),
                    Costo = table.Column<double>(nullable: false),
                    PrecioVenta = table.Column<double>(nullable: false),
                    IVA = table.Column<double>(nullable: false),
                    CantidadMinima = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    InventarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MFactura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMfactura = table.Column<int>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false),
                    TercerosId = table.Column<int>(nullable: false),
                    TipoMovimientoId = table.Column<int>(nullable: false),
                    TipoMovimiento = table.Column<string>(nullable: true),
                    FechaFactura = table.Column<DateTime>(nullable: false),
                    FechaPago = table.Column<DateTime>(nullable: true),
                    SubTotal = table.Column<double>(nullable: false),
                    ValorDevolucion = table.Column<double>(nullable: false),
                    Descuento = table.Column<double>(nullable: false),
                    IVA = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Abono = table.Column<double>(nullable: false),
                    EstadoFactura = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MFactura_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MFactura_Terceros_TercerosId",
                        column: x => x.TercerosId,
                        principalTable: "Terceros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MFactura_TipoMovimiento_TipoMovimientoId",
                        column: x => x.TipoMovimientoId,
                        principalTable: "TipoMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Liquidacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NominaId = table.Column<string>(nullable: true),
                    IdEmpleado = table.Column<int>(nullable: false),
                    Mes = table.Column<int>(nullable: false),
                    Anio = table.Column<int>(nullable: false),
                    SueldoOrdinario = table.Column<double>(nullable: false),
                    SubTransporte = table.Column<double>(nullable: false),
                    TotalDevengado = table.Column<double>(nullable: false),
                    Salud = table.Column<double>(nullable: false),
                    Pension = table.Column<double>(nullable: false),
                    TotalDeducido = table.Column<double>(nullable: false),
                    TotalPagar = table.Column<double>(nullable: false),
                    TotalLiquidacionId = table.Column<int>(nullable: true),
                    NominaId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liquidacion_Nomina_NominaId1",
                        column: x => x.NominaId1,
                        principalTable: "Nomina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Liquidacion_TotalLiquidacion_TotalLiquidacionId",
                        column: x => x.TotalLiquidacionId,
                        principalTable: "TotalLiquidacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DFactura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDFactura = table.Column<int>(nullable: false),
                    MfacturaId = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(nullable: true),
                    idPromocion = table.Column<int>(nullable: true),
                    Bodega = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<double>(nullable: false),
                    PrecioTotal = table.Column<double>(nullable: false),
                    FechaFactura = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DFactura_MFactura_MfacturaId",
                        column: x => x.MfacturaId,
                        principalTable: "MFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoDFactura_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "Id", "Apellidos", "Cargo", "Celular", "Correo", "Direccion", "Estado", "FechaIngreso", "IdEmpleado", "Nombres" },
                values: new object[] { 1, "Ferra Ito", "Cajero", "31688888", "RHerna@gmail.com", "Stranger Valley", "Activo", new DateTime(2021, 4, 29, 21, 14, 46, 953, DateTimeKind.Local).AddTicks(1289), 2699540, "Raul Hernandez" });

            migrationBuilder.InsertData(
                table: "Inventario",
                columns: new[] { "Id", "Bodega", "Cantidad", "Referencia" },
                values: new object[] { 1, "BD01", 5, "1000-01" });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "Id", "CantidadMinima", "Costo", "Descripcion", "Estado", "Fabrica", "FechaRegistro", "FormatoVenta", "IVA", "InventarioId", "Marca", "PrecioVenta", "Referencia" },
                values: new object[] { 1, 0, 3000.0, "Llave Inglesa", null, "Ferres SAS", new DateTime(2021, 4, 29, 21, 14, 46, 948, DateTimeKind.Local).AddTicks(4655), "Unidad", 0.29999999999999999, null, "Ferres", 5000.0, "1000-01" });

            migrationBuilder.InsertData(
                table: "Terceros",
                columns: new[] { "Id", "Apellido", "Celular", "Correo", "Descripcion", "Direccion", "Estado", "FechaCumple", "Nit", "Nombre", "TipoTercero" },
                values: new object[,]
                {
                    { 1, "Orosco Eter", "3128288", "ferreymas@gmail.com", " Empresa Ferreos y Mas", "Stranger Valley", null, new DateTime(2021, 4, 29, 21, 14, 46, 954, DateTimeKind.Local).AddTicks(427), "106583", "Santana Silva", "Proveedor" },
                    { 2, "Joestar", "3443288", "jojo@gmail.com", "Cliente Frecuente", "Stranger Valley", null, new DateTime(2021, 4, 29, 21, 14, 46, 954, DateTimeKind.Local).AddTicks(1543), "10653434", "Jose Jose", "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "TipoMovimiento",
                columns: new[] { "Id", "Nombre", "idMovimiento" },
                values: new object[,]
                {
                    { 1, "Efectivo", 1 },
                    { 2, "Credito", 2 },
                    { 3, "Cheque", 3 },
                    { 4, "Pago Virtual", 4 },
                    { 5, "Devolucion", 5 }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "EmpleadoId", "Nombre", "Password", "Rol" },
                values: new object[] { 1, 1, "RaulH", "EAAAAHDlgUkazfaO5QNj7D / gFmseTKDUliA11ginT5ElAN + V", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_DFactura_MfacturaId",
                table: "DFactura",
                column: "MfacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidacion_NominaId1",
                table: "Liquidacion",
                column: "NominaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidacion_TotalLiquidacionId",
                table: "Liquidacion",
                column: "TotalLiquidacionId");

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
                name: "IX_Producto_InventarioId",
                table: "Producto",
                column: "InventarioId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpleadoId",
                table: "Usuario",
                column: "EmpleadoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormatoVenta");

            migrationBuilder.DropTable(
                name: "Liquidacion");

            migrationBuilder.DropTable(
                name: "ProductoDFactura");

            migrationBuilder.DropTable(
                name: "PromocionesDFactura");

            migrationBuilder.DropTable(
                name: "Tiempo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Nomina");

            migrationBuilder.DropTable(
                name: "TotalLiquidacion");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "DFactura");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "MFactura");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Terceros");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");
        }
    }
}
