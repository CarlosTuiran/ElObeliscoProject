using Domain.Models.Entities;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using System;

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
            optionsBuilder.UseSqlServer("Data Source=SQLEXPRESS; Initial Catalog=ObeliescoDB Trusted_Connection=True;");
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




    }
}
