using Domain.Models.Entities;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infra.Datos
{
    public class ObeliscoContext : DbContextBase
    {
        public ObeliscoContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost/SQLEXPRESS;Database=master;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=ObeliescoDB; Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EstudianteCuerso>().HasKey(x => new { x.CursoId, x.EstudianteId });//llave compuesta 
            //modelBuilder.Entity<EstudianteCuerso>().HasQueryFilter(x=> x.Estado=="Activo");//Filtro por tipo que siempre se activa
            //        puede ignorarse con IgnoreQueryFliters
            modelBuilder.Entity<Producto>().HasData(
                new Producto() { Referencia = "1000-01", Costo = 3000, Descripcion = "Llave Inglesa", Marca = "Ferres", Fabrica = "Ferres SAS",
                    FechaRegistro = DateTime.Now, FormatoVenta = "Unidad", IVA = 0.3, PrecioVenta = 5000, Id=1 });
            modelBuilder.Entity<Inventario>().HasData(
                new Inventario() { Referencia= "1000-01", Bodega="BD01", Cantidad=5, Id=1
                    
            });
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado(){IdEmpleado= 2699540, Nombres="Raul Hernandez", Apellidos="Ferra Ito", Cargo="Cajero", Celular="31688888",
                Correo="RHerna@gmail.com", Direccion="Stranger Valley", Estado="Activo", Id=1, NominaId=1
                });
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario(){EmpleadoId= 1, Nombre="RaulH", Password="raulh", Id=1
                });
            modelBuilder.Entity<Nomina>().HasData(
                new Nomina(){ IdEmpleado= 2699540, IdNomina=1, SaldoBase=1400000, Seguro=100000, Id=1
                });
            modelBuilder.Entity<Liquidacion>().HasData(
                new Liquidacion() { Monto=1500000, FechaPago=DateTime.Now, NominaId=1,Id = 1
                });
            modelBuilder.Entity<Terceros>().HasData(
                new Terceros(){Nit="106583", Nombre="Santana Silva", Apellido="Orosco Eter", Descripcion=" Empresa Ferreos y Mas", 
                    Celular="3128288", Direccion= "Stranger Valley", Correo="ferreymas@gmail.com", TipoTercero="Proveedor",
                    Id = 1
                });
            modelBuilder.Entity<Terceros>().HasData(
                new Terceros(){Nit = "10653434", Nombre = "Jose Jose", Apellido = "Joestar",  Descripcion = "Cliente Frecuente",
                    Celular = "3443288",  Direccion = "Stranger Valley",  Correo = "jojo@gmail.com", TipoTercero = "Cliente",
                    Id = 2
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento{ idMovimiento=1, Nombre="Efectivo", Id=1
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento{ idMovimiento = 2, Nombre = "Credito", Id = 2
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento{idMovimiento = 3, Nombre = "Cheque", Id = 3
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento{idMovimiento = 4, Nombre = "Pago Virtual", Id = 4
                });
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento{idMovimiento = 5, Nombre = "Devolucion", Id = 5
                });
            modelBuilder.Entity<Tiempo>().HasData(
                new Tiempo{ Id=12, Año=2020, Mes=1, Dia=3, DiaDelAño=3, Fecha=Convert.ToDateTime("03-01-2020"), NombreDia="Lunes",
                NombreDiaCorto="LUN", NombreMes="Enero", NombreMesCorto="ENE", SemanaDelAño=1, Semestre=1, Trimestre=1
                });
            modelBuilder.Entity<MFactura>().HasData(
                new MFactura() {idMfactura=1000, TipoMovimiento="Compra", FechaFactura=12, EstadoFactura="Pagada",
                EmpleadoId=1, TercerosId=1, FechaPago=12, IVA=0.3, SubTotal=15000, Descuento=0, Abono=0, Id=1, TipoMovimientoId=1
                });
            modelBuilder.Entity<DFactura>().HasData(
                new DFactura(){MfacturaId=1, idDFactura=10001, Cantidad=5, Bodega="BD1", FechaFactura=12, 
                    PrecioUnitario=3000,Referencia="1000-01", Id=1
                });
            //Restringe las llaves foraneas en el parametro OnDelete 
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
           {
             relationship.DeleteBehavior = DeleteBehavior.Restrict;
           }

            /*MODELO PARA AÑADIR SEEDS
             * modelBuilder.Entity<>().HasData(
                new
                {
                });
            */
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



    }
}
