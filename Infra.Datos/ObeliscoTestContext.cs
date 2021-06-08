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
            modelBuilder.Entity<Marca>().HasData(new Marca(){ Id=1, Nombre="Bolzenaro SA" });
            modelBuilder.Entity<Marca>().HasData(new Marca() { Id = 2, Nombre = "CocaCola" });
            modelBuilder.Entity<Categoria>().HasData( new Categoria(){ Id=1, Nombre="Metalicos" });
            modelBuilder.Entity<Categoria>().HasData( new Categoria(){ Id=2, Nombre="Polvos" });

            modelBuilder.Entity<Producto>().HasData(
                new Producto() { Referencia = "1000-01", Costo = 3000, Descripcion = "Llave Inglesa",
                    IdMarca = 1, IdCategoria = 1, IdProveedor = "106583", Fabrica = "Ferres SAS", FechaRegistro = DateTime.Now, 
                    FormatoVenta = "Unidad", PrecioVenta = 5000, Id=1 });
            modelBuilder.Entity<Inventario>().HasData(
                new Inventario() { Referencia= "1000-01", Bodega="BD01", Cantidad=5, Id=1
                    
            });
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado(){IdEmpleado= 2699540, Nombres="Raul Hernandez", Apellidos="Ferra Ito", Cargo="Cajero", Celular="31688888",
                Correo="RHerna@gmail.com", Direccion="Stranger Valley", Estado="Activo", FechaIngreso=DateTime.Now,Id=1
                });
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario(){EmpleadoId= 1, Nombre="RaulH", Password="raulh", Rol="Admin" ,Id=1
                });
            //construir seeds cuando se tenga claro la nomina
            modelBuilder.Entity<Nomina>().HasData(
                new Nomina(){ IdEmpleado= 2699540, IdNomina="10de2020",  SalarioBase=1400000,  Id=1
                });
            /*modelBuilder.Entity<Liquidacion>().HasData(
                new Liquidacion() { Monto=1500000, FechaPago=DateTime.Now, NominaId=1,Id = 1
                });*/
            modelBuilder.Entity<Terceros>().HasData(
                new Terceros(){Identificacion="106583", Nombre="Santana Silva", Apellido="Orosco Eter", Descripcion=" Empresa Ferreos y Mas", 
                    Celular="3128288", Direccion= "Stranger Valley", Correo="ferreymas@gmail.com", TipoTercero="Proveedor", FechaCumple=DateTime.Now,
                    Id = 1
                });
            modelBuilder.Entity<Terceros>().HasData(
                new Terceros(){Identificacion = "10653434", Nombre = "Jose Jose", Apellido = "Joestar",  Descripcion = "Cliente Frecuente",
                    Celular = "3443288",  Direccion = "Stranger Valley",  Correo = "jojo@gmail.com", TipoTercero = "Cliente", FechaCumple=DateTime.Now,
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
            modelBuilder.Entity<MFactura>().HasData(
                new MFactura() {idMfactura=1000, TipoMovimiento="Compra", FechaFactura=DateTime.Now, EstadoFactura="Pagada",
                EmpleadoId=1, TercerosId=1, FechaPago=DateTime.Now, IVA=0.3, SubTotal=15000, Descuento=0, Abono=0, Id=1, TipoMovimientoId=1
                });
            modelBuilder.Entity<DFactura>().HasData(
                new DFactura(){MfacturaId=1, Cantidad=5, Bodega="BD1", FechaFactura=DateTime.Now, 
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
