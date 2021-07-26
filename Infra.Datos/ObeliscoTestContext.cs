using Domain.Models.Entities;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infra.Datos
{
    public class ObeliscoTestContext : DbContextBase
    {
        public ObeliscoTestContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost/SQLEXPRESS;Database=master;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=ObeliescoDB; Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<EstudianteCuerso>().HasKey(x => new { x.CursoId, x.EstudianteId });//llave compuesta 
            //modelBuilder.Entity<EstudianteCuerso>().HasQueryFilter(x=> x.Estado=="Activo");//Filtro por tipo que siempre se activa
            //        puede ignorarse con IgnoreQueryFliters
            modelBuilder.Entity<Producto>().HasData(
                new Producto()
                {
                    Referencia = "1000-01",
                    Costo = 3000,
                    Descripcion = "Llave Inglesa",
                    IdMarca = 1,
                    IdCategoria = 1,
                    IdProveedor = "106583",
                    Fabrica = "Ferres SAS",
                    FechaRegistro = DateTime.Now,
                    FormatoVenta = "Unidad",
                    PrecioVenta = 5000,
                    Id = 1
                });
            modelBuilder.Entity<Impuesto>().HasData(
                new Impuesto()
                {
                    Id = 1,
                    Nombre = "IVA 16",
                    Tarifa = 0.16,
                    Tipo = "IVA",
                    Activo = true
                });
            modelBuilder.Entity<Inventario>().HasData(
                new Inventario()
                {
                    Referencia = "1000-01",
                    Bodega = "BD01",
                    Cantidad = 5,
                    Id = 1

                });
            modelBuilder.Entity<Empleado>().HasData(
               new Empleado()
               {
                   IdEmpleado = 2699540,
                   Nombres = "Raul Hernandez",
                   Apellidos = "Ferra Ito",
                   Cargo = "Cajero",
                   Celular = "31688888",
                   Correo = "RHerna@gmail.com",
                   Direccion = "Stranger Valley",
                   Estado = "Activo",
                   FechaIngreso = DateTime.Now,
                   Id = 1
               });
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario()
                {
                    EmpleadoId = 1,
                    Nombre = "RaulH",
                    Password = "EAAAAHDlgUkazfaO5QNj7D / gFmseTKDUliA11ginT5ElAN + V",
                    Rol = "Admin",
                    Id = 1
                });
            //CREAR SEEDS CUANTO SE TENGA CLARO LA NOMINA
            /*modelBuilder.Entity<Nomina>().HasData(
                new Nomina(){ IdEmpleado= 2699540, IdNomina=1,  SalarioBase=1400000, Seguro=100000, Id=1
                });
            modelBuilder.Entity<Liquidacion>().HasData(
                new Liquidacion() { Monto=1500000, 
                    FechaPago=DateTime.Now, NominaId=1,Id = 1
                });*/
            modelBuilder.Entity<Terceros>().HasData(
                new Terceros()
                {
                    Identificacion = "106583",
                    Nombre = "Santana Silva",
                    Apellido = "Orosco Eter",
                    Descripcion = " Empresa Ferreos y Mas",
                    Celular = "3128288",
                    Direccion = "Stranger Valley",
                    Correo = "ferreymas@gmail.com",
                    TipoTercero = "Proveedor",
                    FechaCumple = DateTime.Now,
                    Id = 1
                });
            modelBuilder.Entity<Terceros>().HasData(
                new Terceros()
                {
                    Identificacion = "10653434",
                    Nombre = "Jose Jose",
                    Apellido = "Joestar",
                    Descripcion = "Cliente Frecuente",
                    Celular = "3443288",
                    Direccion = "Stranger Valley",
                    Correo = "jojo@gmail.com",
                    TipoTercero = "Cliente",
                    FechaCumple = DateTime.Now,
                    Id = 2
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento
                {
                    idMovimiento = 1,
                    Nombre = "Efectivo",
                    Id = 1
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento
                {
                    idMovimiento = 2,
                    Nombre = "Credito",
                    Id = 2
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento
                {
                    idMovimiento = 3,
                    Nombre = "Cheque",
                    Id = 3
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento
                {
                    idMovimiento = 4,
                    Nombre = "Pago Virtual",
                    Id = 4
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento
                {
                    idMovimiento = 5,
                    Nombre = "Devolucion",
                    Id = 5
                });
            modelBuilder.Entity<Nomina>().HasData(
                new Nomina
                {
                    Id=1,
                    Comisiones=10000,
                    DiasTrabajados=30,
                    HoraExtraDiurna=0,
                    HoraExtraDiurnaFestivo=0,
                    HoraExtraNocturna=0,
                    HoraExtraNocturnaFestivo=0,
                    IdEmpleado=2699540,
                    IdNomina= DateTime.Now.Month + " - " + DateTime.Now.Year,
                    SalarioBase = 1200000
                });


            modelBuilder.Entity<Parametros>().HasData(
            //Partida Doble Cuenta Nomina Agrupacion 1 
            new Parametros
            {
                Agrupacion = "CuentaNomina",
                Descripcion = "retencion aporte nomina",
                ValorNumerico = 2370,
                ValorTxt = "",
                Id = 1
            },
            new Parametros
            {
                Agrupacion = "CuentaNomina",
                Descripcion = "acreedores varios",
                ValorNumerico = 2380,
                ValorTxt = "",
                Id = 2
            },
            new Parametros
            {
                Agrupacion = "CuentaNomina",
                Descripcion = "provision",
                ValorNumerico = 2610,
                ValorTxt = "",
                Id = 3
            },
            new Parametros
            {
                Agrupacion = "CuentaNomina",
                Descripcion = "salarios por pagar",
                ValorNumerico = 2505,
                ValorTxt = "",
                Id = 4
            },
            new Parametros
            {
                Agrupacion = "CuentaNomina",
                Descripcion = "gasto personal",
                ValorNumerico = 5105,
                ValorTxt = "",
                Id = 5

            },
            //Parametros Nomina
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "SALUDEMPLEADOR",
                ValorNumerico = 8.5,
                ValorTxt = "TOTAL_SALARIO",
                Id = 6
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "SALUDTRABAJADOR",
                ValorNumerico = 4,
                ValorTxt = "TOTAL_SALARIO",
                Id = 7
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "PENSIONEMPLEADOR",
                ValorNumerico = 12,
                ValorTxt = "TOTAL_SALARIO",
                Id = 8

            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "PENSIONTRABAJADOR",
                ValorNumerico = 4,
                ValorTxt = "TOTAL_SALARIO",
                Id = 9
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "ARL",
                ValorNumerico = 0.52,
                ValorTxt = "TOTAL_SALARIO",
                Id = 10
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "CESANTIAS",
                ValorNumerico = 8.33,
                ValorTxt = "TOTAL_DEVENGADO",
                Id = 11
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "INT CESANTIAS",
                ValorNumerico = 1,
                ValorTxt = "CESANTIA",
                Id = 12
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "VACACIONES",
                ValorNumerico = 4.17,
                ValorTxt = "SALARIO_BASICO",
                Id = 13
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "CAJACOMPENSACION",
                ValorNumerico = 4,
                ValorTxt = "TOTAL_SALARIO",
                Id = 14
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "ICBF",
                ValorNumerico = 3,
                ValorTxt = "TOTAL_SALARIO",
                Id = 15
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "SENA",
                ValorNumerico = 2,
                ValorTxt = "TOTAL_SALARIO",
                Id = 16
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "SALARIO_MINIMO",
                ValorNumerico = 908.526,
                ValorTxt = "",
                Id = 17
            },
            new Parametros
            {
                Agrupacion = "ParametrosNomina",
                Descripcion = "AUX_TRANSPORTE",
                ValorNumerico = 106.454,
                ValorTxt = "",
                Id = 18
            },

            //Parametros Tipo pago
            new Parametros
            {
                Agrupacion = "ParametrosTipoPago",
                Descripcion = "Efectivo",
                ValorNumerico = 1105,
                ValorTxt = "",
                Id = 19
            },
            new Parametros
            {
                Agrupacion = "ParametrosTipoPago",
                Descripcion = "Credito",
                ValorNumerico = 2335,
                ValorTxt = "",
                Id = 20
            },
            new Parametros
            {
                Agrupacion = "ParametrosTipoPago",
                Descripcion = "Cheque",
                ValorNumerico = 1110,
                ValorTxt = "",
                Id = 21
            },
            new Parametros
            {
                Agrupacion = "ParametrosTipoPago",
                Descripcion = "Pago Virtual",
                ValorNumerico = 1110,
                ValorTxt = "",
                Id = 22
            },
            // Parametros Horas extras
            new Parametros
            {
                Agrupacion = "ParametrosHorasExtras",
                Descripcion = "Diurno",
                ValorNumerico = 25,
                ValorTxt = "",
                Id = 23
            },
            new Parametros
            {
                Agrupacion = "ParametrosHorasExtras",
                Descripcion = "Nocturno",
                ValorNumerico = 75,
                ValorTxt = "",
                Id = 24
            },
            new Parametros
            {
                Agrupacion = "ParametrosHorasExtras",
                Descripcion = "Diurno_Festivo",
                ValorNumerico = 100,
                ValorTxt = "",
                Id = 25
            },
            new Parametros
            {
                Agrupacion = "ParametrosHorasExtras",
                Descripcion = "Nocturno_Festivo",
                ValorNumerico = 150,
                ValorTxt = "",
                Id = 26
            });

            //Restringe las llaves foraneas en el parametro OnDelete 
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<DFactura> DFactura { get; set; }
        public DbSet<MFactura> MFactura { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Terceros> Terceros { get; set; }
        public DbSet<Nomina> Nomina { get; set; }
        public DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Liquidacion> Liquidacion { get; set; }
        public DbSet<Tiempo> Tiempo { get; set; }
        public DbSet<TotalLiquidacion> TotalLiquidacion { get; set; }
        public DbSet<FormatoVenta> FormatoVenta { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Impuesto> Impuesto { get; set; }
        public DbSet<ImpuestosProducto> ImpuestosProducto { get; set; }
        public DbSet<LibroContable> LibroContable { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Bodega> Bodega { get; set; }
    }
}
