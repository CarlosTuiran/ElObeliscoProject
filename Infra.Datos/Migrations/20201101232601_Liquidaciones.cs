using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class Liquidaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Nomina_NominaId",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Liquidacion_Nomina_NominaId",
                table: "Liquidacion");

            migrationBuilder.DropIndex(
                name: "IX_Liquidacion_NominaId",
                table: "Liquidacion");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_NominaId",
                table: "Empleado");

            migrationBuilder.DeleteData(
                table: "Liquidacion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nomina",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SaldoBase",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Seguro",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "IdLiquidacion",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "NominaId",
                table: "Empleado");

            migrationBuilder.AlterColumn<string>(
                name: "IdNomina",
                table: "Nomina",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DiasTrabajados",
                table: "Nomina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorasExtras",
                table: "Nomina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SalarioBase",
                table: "Nomina",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SubTransporte",
                table: "Nomina",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "NominaId",
                table: "Liquidacion",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpleado",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mes",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NominaId1",
                table: "Liquidacion",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Pension",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Salud",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SubTransporte",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SueldoOrdinario",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDeducido",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDevengado",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalLiquidacionId",
                table: "Liquidacion",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPagar",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2020, 11, 1, 18, 26, 0, 598, DateTimeKind.Local).AddTicks(3685));

            migrationBuilder.CreateIndex(
                name: "IX_Liquidacion_NominaId1",
                table: "Liquidacion",
                column: "NominaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidacion_TotalLiquidacionId",
                table: "Liquidacion",
                column: "TotalLiquidacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Liquidacion_Nomina_NominaId1",
                table: "Liquidacion",
                column: "NominaId1",
                principalTable: "Nomina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Liquidacion_TotalLiquidacion_TotalLiquidacionId",
                table: "Liquidacion",
                column: "TotalLiquidacionId",
                principalTable: "TotalLiquidacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Liquidacion_Nomina_NominaId1",
                table: "Liquidacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Liquidacion_TotalLiquidacion_TotalLiquidacionId",
                table: "Liquidacion");

            migrationBuilder.DropTable(
                name: "TotalLiquidacion");

            migrationBuilder.DropIndex(
                name: "IX_Liquidacion_NominaId1",
                table: "Liquidacion");

            migrationBuilder.DropIndex(
                name: "IX_Liquidacion_TotalLiquidacionId",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "DiasTrabajados",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "HorasExtras",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "SalarioBase",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "SubTransporte",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Anio",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "IdEmpleado",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "NominaId1",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Pension",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Salud",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "SubTransporte",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "SueldoOrdinario",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "TotalDeducido",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "TotalDevengado",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "TotalLiquidacionId",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "TotalPagar",
                table: "Liquidacion");

            migrationBuilder.AlterColumn<int>(
                name: "IdNomina",
                table: "Nomina",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaldoBase",
                table: "Nomina",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Seguro",
                table: "Nomina",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "NominaId",
                table: "Liquidacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "Liquidacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdLiquidacion",
                table: "Liquidacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Monto",
                table: "Liquidacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NominaId",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Nomina",
                columns: new[] { "Id", "IdEmpleado", "IdNomina", "SaldoBase", "Seguro" },
                values: new object[] { 1, 2699540, 1, 1400000.0, 100000.0 });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2020, 9, 20, 13, 27, 48, 931, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "NominaId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Liquidacion",
                columns: new[] { "Id", "FechaPago", "IdLiquidacion", "Monto", "NominaId" },
                values: new object[] { 1, new DateTime(2020, 9, 20, 13, 27, 48, 961, DateTimeKind.Local).AddTicks(8467), 0, 1500000.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Liquidacion_NominaId",
                table: "Liquidacion",
                column: "NominaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_NominaId",
                table: "Empleado",
                column: "NominaId");

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
        }
    }
}
