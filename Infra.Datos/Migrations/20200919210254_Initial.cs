using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IdNomina = table.Column<int>(nullable: false),
                    IdEmpleado = table.Column<int>(nullable: false),
                    SaldoBase = table.Column<double>(nullable: false),
                    Seguro = table.Column<double>(nullable: false)
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
                    Descripcion = table.Column<string>(nullable: true)
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
                    FechaRegistro = table.Column<DateTime>(nullable: false),
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
                    NominaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Nomina_NominaId",
                        column: x => x.NominaId,
                        principalTable: "Nomina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Liquidacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLiquidacion = table.Column<int>(nullable: false),
                    NominaId = table.Column<int>(nullable: false),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liquidacion_Nomina_NominaId",
                        column: x => x.NominaId,
                        principalTable: "Nomina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    FechaFactura = table.Column<int>(nullable: false),
                    FechaPago = table.Column<int>(nullable: true),
                    SubTotal = table.Column<double>(nullable: false),
                    ValorDevolucion = table.Column<double>(nullable: false),
                    Descuento = table.Column<double>(nullable: false),
                    IVA = table.Column<double>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MFactura_Terceros_TercerosId",
                        column: x => x.TercerosId,
                        principalTable: "Terceros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MFactura_TipoMovimiento_TipoMovimientoId",
                        column: x => x.TipoMovimientoId,
                        principalTable: "TipoMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    FechaFactura = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DFactura_MFactura_MfacturaId",
                        column: x => x.MfacturaId,
                        principalTable: "MFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Inventario",
                columns: new[] { "Id", "Bodega", "Cantidad", "Referencia" },
                values: new object[] { 1, "BD01", 5, "1000-01" });

            migrationBuilder.InsertData(
                table: "Nomina",
                columns: new[] { "Id", "IdEmpleado", "IdNomina", "SaldoBase", "Seguro" },
                values: new object[] { 1, 2699540, 1, 1400000.0, 100000.0 });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "Id", "Costo", "Descripcion", "Fabrica", "FechaRegistro", "FormatoVenta", "IVA", "InventarioId", "Marca", "PrecioVenta", "Referencia" },
                values: new object[] { 1, 3000.0, "Llave Inglesa", "Ferres SAS", new DateTime(2020, 9, 19, 16, 2, 52, 503, DateTimeKind.Local).AddTicks(2335), "Unidad", 0.29999999999999999, null, "Ferres", 5000.0, "1000-01" });

            migrationBuilder.InsertData(
                table: "Terceros",
                columns: new[] { "Id", "Apellido", "Celular", "Correo", "Descripcion", "Direccion", "Nit", "Nombre", "TipoTercero" },
                values: new object[,]
                {
                    { 1, "Orosco Eter", "3128288", "ferreymas@gmail.com", " Empresa Ferreos y Mas", "Stranger Valley", "106583", "Santana Silva", "Proveedor" },
                    { 2, "Joestar", "3443288", "jojo@gmail.com", "Cliente Frecuente", "Stranger Valley", "10653434", "Jose Jose", "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Tiempo",
                columns: new[] { "Id", "Año", "Dia", "DiaDelAño", "Fecha", "Mes", "NombreDia", "NombreDiaCorto", "NombreMes", "NombreMesCorto", "SemanaDelAño", "Semestre", "Trimestre" },
                values: new object[] { 12, 2020, 3, 3, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lunes", "LUN", "Enero", "ENE", 1, 1, 1 });

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
                table: "Empleado",
                columns: new[] { "Id", "Apellidos", "Cargo", "Celular", "Correo", "Direccion", "Estado", "IdEmpleado", "Nombres", "NominaId" },
                values: new object[] { 1, "Ferra Ito", "Cajero", "31688888", "RHerna@gmail.com", "Stranger Valley", "Activo", 2699540, "Raul Hernandez", 1 });

            migrationBuilder.InsertData(
                table: "Liquidacion",
                columns: new[] { "Id", "FechaPago", "IdLiquidacion", "Monto", "NominaId" },
                values: new object[] { 1, new DateTime(2020, 9, 19, 16, 2, 52, 513, DateTimeKind.Local).AddTicks(540), 0, 1500000.0, 1 });

            migrationBuilder.InsertData(
                table: "MFactura",
                columns: new[] { "Id", "Abono", "Descuento", "EmpleadoId", "EstadoFactura", "FechaFactura", "FechaPago", "IVA", "SubTotal", "TercerosId", "TipoMovimiento", "TipoMovimientoId", "ValorDevolucion", "idMfactura" },
                values: new object[] { 1, 0.0, 0.0, 1, "Pagada", 12, 12, 0.29999999999999999, 15000.0, 1, "Compra", 1, 0.0, 1000 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "EmpleadoId", "Nombre", "Password" },
                values: new object[] { 1, 1, "RaulH", "raulh" });

            migrationBuilder.InsertData(
                table: "DFactura",
                columns: new[] { "Id", "Bodega", "Cantidad", "FechaFactura", "MfacturaId", "PrecioUnitario", "Referencia", "idDFactura", "idPromocion" },
                values: new object[] { 1, "BD1", 5, 12, 1, 3000.0, "1000-01", 10001, null });

            migrationBuilder.CreateIndex(
                name: "IX_DFactura_MfacturaId",
                table: "DFactura",
                column: "MfacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_NominaId",
                table: "Empleado",
                column: "NominaId");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidacion_NominaId",
                table: "Liquidacion",
                column: "NominaId");

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

            migrationBuilder.DropTable(
                name: "Nomina");
        }
    }
}
