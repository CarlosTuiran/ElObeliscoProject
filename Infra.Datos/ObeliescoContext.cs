using Domain.Models.Entities;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Datos
{
    public class ObeliescoContext : DbContextBase
    {
        public ObeliescoContext(DbContextOptions options) : base(options)
        {
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
        }*/
        public DbSet<DFactura> DFactura { get; set; }
        public DbSet<MFactura> MFactura { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}
