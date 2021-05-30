using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Datos.Migrations
{
    public partial class Nomina_Liquidacion_Total : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comfacesar",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "HorasExtras",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "SubTransporte",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Pension",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Salud",
                table: "Liquidacion");

            migrationBuilder.RenameColumn(
                name: "Sena",
                table: "TotalLiquidacion",
                newName: "SENA");

            migrationBuilder.RenameColumn(
                name: "Icbf",
                table: "TotalLiquidacion",
                newName: "ICBF");

            migrationBuilder.AddColumn<double>(
                name: "AcreedoresVarios",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Arl",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Caja_Comp",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Cesantias",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Int_Cesantias",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Parafiscales",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pension",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pension_Empleador",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pension_Trabajador",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Prima",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Provision",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RetencionAporteNomina",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SalariosPagar",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Salud",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Salud_Empleador",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Salud_Trabajador",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SubTransporte",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Sueldo",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDevengado",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Vacaciones",
                table: "TotalLiquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Comisiones",
                table: "Nomina",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HoraExtraDiurna",
                table: "Nomina",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HoraExtraDiurnaFestivo",
                table: "Nomina",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HoraExtraNocturna",
                table: "Nomina",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HoraExtraNocturnaFestivo",
                table: "Nomina",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Arl",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Caja_Comp",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Cesantias",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ICBF",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Int_Cesantias",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pension_Empleador",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pension_Trabajador",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Prima",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SENA",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Salud_Empleador",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Salud_Trabajador",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Vacaciones",
                table: "Liquidacion",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agrupacion = table.Column<string>(nullable: true),
                    ValorNumerico = table.Column<double>(nullable: false),
                    ValorTxt = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2021, 5, 29, 20, 9, 40, 809, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Agrupacion", "Descripcion", "ValorNumerico", "ValorTxt" },
                values: new object[,]
                {
                    { 26, "ParametrosHorasExtras", "Nocturno_Festivo", 150.0, "" },
                    { 25, "ParametrosHorasExtras", "Diurno_Festivo", 100.0, "" },
                    { 24, "ParametrosHorasExtras", "Nocturno", 75.0, "" },
                    { 23, "ParametrosHorasExtras", "Diurno", 25.0, "" },
                    { 22, "ParametrosTipoPago", "Pago Virtual", 1110.0, "" },
                    { 21, "ParametrosTipoPago", "Cheque", 1110.0, "" },
                    { 20, "ParametrosTipoPago", "Credito", 2335.0, "" },
                    { 19, "ParametrosTipoPago", "Efectivo", 1105.0, "" },
                    { 18, "ParametrosNomina", "AUX_TRANSPORTE", 106.45399999999999, "" },
                    { 17, "ParametrosNomina", "SALARIO_MINIMO", 908.52599999999995, "" },
                    { 16, "ParametrosNomina", "SENA", 2.0, "TOTAL_SALARIO" },
                    { 14, "ParametrosNomina", "CAJACOMPENSACION", 4.0, "TOTAL_SALARIO" },
                    { 15, "ParametrosNomina", "ICBF", 3.0, "TOTAL_SALARIO" },
                    { 12, "ParametrosNomina", "INT CESANTIAS", 1.0, "CESANTIA" },
                    { 11, "ParametrosNomina", "CESANTIAS", 8.3300000000000001, "TOTAL_DEVENGADO" },
                    { 10, "ParametrosNomina", "ARL", 0.52000000000000002, "TOTAL_SALARIO" },
                    { 9, "ParametrosNomina", "PENSIONTRABAJADOR", 4.0, "TOTAL_SALARIO" },
                    { 8, "ParametrosNomina", "PENSIONEMPLEADOR", 12.0, "TOTAL_SALARIO" },
                    { 7, "ParametrosNomina", "SALUDTRABAJADOR", 4.0, "TOTAL_SALARIO" },
                    { 6, "ParametrosNomina", "SALUDEMPLEADOR", 8.5, "TOTAL_SALARIO" },
                    { 5, "CuentaNomina", "gasto personal", 5105.0, "" },
                    { 4, "CuentaNomina", "salarios por pagar", 2505.0, "" },
                    { 3, "CuentaNomina", "provision", 2610.0, "" },
                    { 2, "CuentaNomina", "acreedores varios", 2380.0, "" },
                    { 13, "ParametrosNomina", "VACACIONES", 4.1699999999999999, "SALARIO_BASICO" },
                    { 1, "CuentaNomina", "retencion aporte nomina", 2370.0, "" }
                });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 5, 29, 20, 9, 40, 806, DateTimeKind.Local).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 29, 20, 9, 40, 811, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "Terceros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCumple",
                value: new DateTime(2021, 5, 29, 20, 9, 40, 811, DateTimeKind.Local).AddTicks(1566));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropColumn(
                name: "AcreedoresVarios",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Arl",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Caja_Comp",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Cesantias",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Int_Cesantias",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Parafiscales",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Pension",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Pension_Empleador",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Pension_Trabajador",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Prima",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Provision",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "RetencionAporteNomina",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "SalariosPagar",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Salud",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Salud_Empleador",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Salud_Trabajador",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "SubTransporte",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Sueldo",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "TotalDevengado",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Vacaciones",
                table: "TotalLiquidacion");

            migrationBuilder.DropColumn(
                name: "Comisiones",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "HoraExtraDiurna",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "HoraExtraDiurnaFestivo",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "HoraExtraNocturna",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "HoraExtraNocturnaFestivo",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Arl",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Caja_Comp",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Cesantias",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "ICBF",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Int_Cesantias",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Pension_Empleador",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Pension_Trabajador",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Prima",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "SENA",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Salud_Empleador",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Salud_Trabajador",
                table: "Liquidacion");

            migrationBuilder.DropColumn(
                name: "Vacaciones",
                table: "Liquidacion");

            migrationBuilder.RenameColumn(
                name: "SENA",
                table: "TotalLiquidacion",
                newName: "Sena");

            migrationBuilder.RenameColumn(
                name: "ICBF",
                table: "TotalLiquidacion",
                newName: "Icbf");

            migrationBuilder.AddColumn<double>(
                name: "Comfacesar",
                table: "TotalLiquidacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "TotalLiquidacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "HorasExtras",
                table: "Nomina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SubTransporte",
                table: "Nomina",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pension",
                table: "Liquidacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Salud",
                table: "Liquidacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
    }
}
