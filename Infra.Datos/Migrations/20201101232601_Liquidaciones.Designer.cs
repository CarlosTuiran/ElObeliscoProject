﻿// <auto-generated />
using System;
using Infra.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Datos.Migrations
{
    [DbContext(typeof(ObeliscoContext))]
    [Migration("20201101232601_Liquidaciones")]
    partial class Liquidaciones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Entities.DFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bodega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("FechaFactura")
                        .HasColumnType("int");

                    b.Property<int>("MfacturaId")
                        .HasColumnType("int");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("float");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idDFactura")
                        .HasColumnType("int");

                    b.Property<int?>("idPromocion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MfacturaId");

                    b.ToTable("DFactura");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bodega = "BD1",
                            Cantidad = 5,
                            FechaFactura = 12,
                            MfacturaId = 1,
                            PrecioUnitario = 3000.0,
                            Referencia = "1000-01",
                            idDFactura = 10001
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empleado");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Ferra Ito",
                            Cargo = "Cajero",
                            Celular = "31688888",
                            Correo = "RHerna@gmail.com",
                            Direccion = "Stranger Valley",
                            Estado = "Activo",
                            IdEmpleado = 2699540,
                            Nombres = "Raul Hernandez"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bodega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inventario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bodega = "BD01",
                            Cantidad = 5,
                            Referencia = "1000-01"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Liquidacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<string>("NominaId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NominaId1")
                        .HasColumnType("int");

                    b.Property<double>("Pension")
                        .HasColumnType("float");

                    b.Property<double>("Salud")
                        .HasColumnType("float");

                    b.Property<double>("SubTransporte")
                        .HasColumnType("float");

                    b.Property<double>("SueldoOrdinario")
                        .HasColumnType("float");

                    b.Property<double>("TotalDeducido")
                        .HasColumnType("float");

                    b.Property<double>("TotalDevengado")
                        .HasColumnType("float");

                    b.Property<int?>("TotalLiquidacionId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPagar")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NominaId1");

                    b.HasIndex("TotalLiquidacionId");

                    b.ToTable("Liquidacion");
                });

            modelBuilder.Entity("Domain.Models.Entities.MFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Abono")
                        .HasColumnType("float");

                    b.Property<double>("Descuento")
                        .HasColumnType("float");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<string>("EstadoFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FechaFactura")
                        .HasColumnType("int");

                    b.Property<int?>("FechaPago")
                        .HasColumnType("int");

                    b.Property<double>("IVA")
                        .HasColumnType("float");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.Property<int>("TercerosId")
                        .HasColumnType("int");

                    b.Property<string>("TipoMovimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoMovimientoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorDevolucion")
                        .HasColumnType("float");

                    b.Property<int>("idMfactura")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("TercerosId");

                    b.HasIndex("TipoMovimientoId");

                    b.ToTable("MFactura");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abono = 0.0,
                            Descuento = 0.0,
                            EmpleadoId = 1,
                            EstadoFactura = "Pagada",
                            FechaFactura = 12,
                            FechaPago = 12,
                            IVA = 0.29999999999999999,
                            SubTotal = 15000.0,
                            TercerosId = 1,
                            TipoMovimiento = "Compra",
                            TipoMovimientoId = 1,
                            ValorDevolucion = 0.0,
                            idMfactura = 1000
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Nomina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiasTrabajados")
                        .HasColumnType("int");

                    b.Property<int>("HorasExtras")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<string>("IdNomina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SalarioBase")
                        .HasColumnType("float");

                    b.Property<double>("SubTransporte")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Nomina");
                });

            modelBuilder.Entity("Domain.Models.Entities.Operacionales.ProductoDFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DFacturaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DFacturaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProductoDFactura");
                });

            modelBuilder.Entity("Domain.Models.Entities.Operacionales.PromocionesDFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DFacturaId")
                        .HasColumnType("int");

                    b.Property<int>("PromocionesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DFacturaId");

                    b.ToTable("PromocionesDFactura");
                });

            modelBuilder.Entity("Domain.Models.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fabrica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormatoVenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("IVA")
                        .HasColumnType("float");

                    b.Property<int?>("InventarioId")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioVenta")
                        .HasColumnType("float");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InventarioId");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Costo = 3000.0,
                            Descripcion = "Llave Inglesa",
                            Fabrica = "Ferres SAS",
                            FechaRegistro = new DateTime(2020, 11, 1, 18, 26, 0, 598, DateTimeKind.Local).AddTicks(3685),
                            FormatoVenta = "Unidad",
                            IVA = 0.29999999999999999,
                            Marca = "Ferres",
                            PrecioVenta = 5000.0,
                            Referencia = "1000-01"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Terceros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoTercero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Terceros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Orosco Eter",
                            Celular = "3128288",
                            Correo = "ferreymas@gmail.com",
                            Descripcion = " Empresa Ferreos y Mas",
                            Direccion = "Stranger Valley",
                            Nit = "106583",
                            Nombre = "Santana Silva",
                            TipoTercero = "Proveedor"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Joestar",
                            Celular = "3443288",
                            Correo = "jojo@gmail.com",
                            Descripcion = "Cliente Frecuente",
                            Direccion = "Stranger Valley",
                            Nit = "10653434",
                            Nombre = "Jose Jose",
                            TipoTercero = "Cliente"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Tiempo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("DiaDelAño")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<string>("NombreDia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreDiaCorto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMesCorto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SemanaDelAño")
                        .HasColumnType("int");

                    b.Property<int>("Semestre")
                        .HasColumnType("int");

                    b.Property<int>("Trimestre")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tiempo");

                    b.HasData(
                        new
                        {
                            Id = 12,
                            Año = 2020,
                            Dia = 3,
                            DiaDelAño = 3,
                            Fecha = new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mes = 1,
                            NombreDia = "Lunes",
                            NombreDiaCorto = "LUN",
                            NombreMes = "Enero",
                            NombreMesCorto = "ENE",
                            SemanaDelAño = 1,
                            Semestre = 1,
                            Trimestre = 1
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.TipoMovimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idMovimiento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TipoMovimiento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Efectivo",
                            idMovimiento = 1
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Credito",
                            idMovimiento = 2
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Cheque",
                            idMovimiento = 3
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Pago Virtual",
                            idMovimiento = 4
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Devolucion",
                            idMovimiento = 5
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.TotalLiquidacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<double>("Comfacesar")
                        .HasColumnType("float");

                    b.Property<double>("Icbf")
                        .HasColumnType("float");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<string>("NominaId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Sena")
                        .HasColumnType("float");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("ValorTotalNomina")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TotalLiquidacion");
                });

            modelBuilder.Entity("Domain.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId")
                        .IsUnique();

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmpleadoId = 1,
                            Nombre = "RaulH",
                            Password = "raulh",
                            Tipo = "Admin"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.DFactura", b =>
                {
                    b.HasOne("Domain.Models.Entities.MFactura", null)
                        .WithMany("DFacturas")
                        .HasForeignKey("MfacturaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Entities.Liquidacion", b =>
                {
                    b.HasOne("Domain.Models.Entities.Nomina", null)
                        .WithMany("Liquidacion")
                        .HasForeignKey("NominaId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Models.Entities.TotalLiquidacion", "TotalLiquidacion")
                        .WithMany()
                        .HasForeignKey("TotalLiquidacionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Models.Entities.MFactura", b =>
                {
                    b.HasOne("Domain.Models.Entities.Empleado", null)
                        .WithMany("MFacturas")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Terceros", null)
                        .WithMany("MFacturas")
                        .HasForeignKey("TercerosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.TipoMovimiento", null)
                        .WithMany("MFacturas")
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Entities.Operacionales.ProductoDFactura", b =>
                {
                    b.HasOne("Domain.Models.Entities.DFactura", null)
                        .WithMany("ProductoDFacturas")
                        .HasForeignKey("DFacturaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Producto", null)
                        .WithMany("ProductoDFacturas")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Entities.Operacionales.PromocionesDFactura", b =>
                {
                    b.HasOne("Domain.Models.Entities.DFactura", null)
                        .WithMany("PromocionesDFacturas")
                        .HasForeignKey("DFacturaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Entities.Producto", b =>
                {
                    b.HasOne("Domain.Models.Entities.Inventario", null)
                        .WithMany("Productos")
                        .HasForeignKey("InventarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Models.Entities.Usuario", b =>
                {
                    b.HasOne("Domain.Models.Entities.Empleado", null)
                        .WithOne("Usuario")
                        .HasForeignKey("Domain.Models.Entities.Usuario", "EmpleadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
