using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos
{
    public class AppDbContext :  IDesignTimeDbContextFactory<ObeliscoContext>
    {
        public ObeliscoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ObeliscoContext>();
            optionsBuilder.UseSqlServer("Data Source=SQLEXPRESS; Initial Catalog=ObeliescoDB Trusted_Connection=True;");
            return new ObeliscoContext(optionsBuilder.Options);
        
        }
    }
}
