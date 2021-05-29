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
    [Migration("20210526010922_LibroContable")]
    partial class LibroContable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Domain.Models.Entities.Cuenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Naturaleza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("Domain.Models.Entities.DFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bodega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<double>("CantidadDigitada")
                        .HasColumnType("float");

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormatoProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("IVA")
                        .HasColumnType("float");

                    b.Property<int>("MfacturaId")
                        .HasColumnType("int");

                    b.Property<double>("PrecioTotal")
                        .HasColumnType("float");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("float");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idPromocion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MfacturaId");

                    b.ToTable("DFactura");
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

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

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
                            FechaIngreso = new DateTime(2021, 5, 25, 20, 9, 21, 665, DateTimeKind.Local).AddTicks(1960),
                            IdEmpleado = 2699540,
                            Nombres = "Raul Hernandez"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.FormatoVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FactorConversion")
                        .HasColumnType("float");

                    b.Property<string>("Metrica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormatoVenta");
                });

            modelBuilder.Entity("Domain.Models.Entities.Impuesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Impuesto");
                });

            modelBuilder.Entity("Domain.Models.Entities.ImpuestosProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdImpuesto")
                        .HasColumnType("int");

                    b.Property<string>("IdProducto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImpuestosProducto");
                });

            modelBuilder.Entity("Domain.Models.Entities.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bodega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inventario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bodega = "BD01",
                            Cantidad = 5.0,
                            Referencia = "1000-01"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.LibroContable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<double?>("Debe")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Haber")
                        .HasColumnType("float");

                    b.Property<int>("OrigenId")
                        .HasColumnType("int");

                    b.Property<string>("OrigenTipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LibroContable");
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

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<double>("IVA")
                        .HasColumnType("float");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Serial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.Property<int>("TercerosId")
                        .HasColumnType("int");

                    b.Property<string>("TipoMovimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoMovimientoId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("ValorDevolucion")
                        .HasColumnType("float");

                    b.Property<int>("idMfactura")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("TercerosId");

                    b.HasIndex("TipoMovimientoId");

                    b.ToTable("MFactura");
                });

            modelBuilder.Entity("Domain.Models.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marca");
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

                    b.Property<int>("CantidadMinima")
                        .HasColumnType("int");

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<int>("CuentaDevolucion")
                        .HasColumnType("int");

                    b.Property<int>("CuentaIngreso")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fabrica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormatoVenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<string>("IdProveedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InventarioId")
                        .HasColumnType("int");

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
                            CantidadMinima = 0,
                            Costo = 3000.0,
                            CuentaDevolucion = 0,
                            CuentaIngreso = 0,
                            Descripcion = "Llave Inglesa",
                            Fabrica = "Ferres SAS",
                            FechaRegistro = new DateTime(2021, 5, 25, 20, 9, 21, 660, DateTimeKind.Local).AddTicks(7032),
                            FormatoVenta = "Unidad",
                            IdCategoria = 1,
                            IdMarca = 1,
                            IdProveedor = "106583",
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

                    b.Property<string>("ActividadEconomica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AutoRetenedor")
                        .HasColumnType("bit");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Extranjero")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCumple")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponsabilidadFiscal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ResponsableIva")
                        .HasColumnType("bit");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPersona")
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
                            AutoRetenedor = false,
                            Celular = "3128288",
                            Correo = "ferreymas@gmail.com",
                            Descripcion = " Empresa Ferreos y Mas",
                            Direccion = "Stranger Valley",
                            Extranjero = false,
                            FechaCumple = new DateTime(2021, 5, 25, 20, 9, 21, 667, DateTimeKind.Local).AddTicks(7373),
                            Identificacion = "106583",
                            Nombre = "Santana Silva",
                            ResponsableIva = false,
                            TipoTercero = "Proveedor"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Joestar",
                            AutoRetenedor = false,
                            Celular = "3443288",
                            Correo = "jojo@gmail.com",
                            Descripcion = "Cliente Frecuente",
                            Direccion = "Stranger Valley",
                            Extranjero = false,
                            FechaCumple = new DateTime(2021, 5, 25, 20, 9, 21, 667, DateTimeKind.Local).AddTicks(9123),
                            Identificacion = "10653434",
                            Nombre = "Jose Jose",
                            ResponsableIva = false,
                            TipoTercero = "Cliente"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Tiempo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Anio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anio_Cuatrimestre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anio_Mes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anio_Semana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anio_Semestre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cuatrimestre_Anio")
                        .HasColumnType("int");

                    b.Property<int>("Dia_Anio")
                        .HasColumnType("int");

                    b.Property<int>("Dia_Mes")
                        .HasColumnType("int");

                    b.Property<int>("Dia_Semana")
                        .HasColumnType("int");

                    b.Property<string>("Dia_Semana_Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdFecha")
                        .HasColumnType("int");

                    b.Property<int>("Mes_Anio")
                        .HasColumnType("int");

                    b.Property<string>("Mes_Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semana_Anio")
                        .HasColumnType("int");

                    b.Property<int>("Semestre_Anio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tiempo");
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

                    b.Property<string>("Rol")
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
                            Password = "EAAAAHDlgUkazfaO5QNj7D / gFmseTKDUliA11ginT5ElAN + V",
                            Rol = "Admin"
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
