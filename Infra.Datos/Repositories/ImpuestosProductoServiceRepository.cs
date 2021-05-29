using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Entities;
namespace Infra.Datos.Repositories
{
    public class ImpuestosProductoServiceRepository : GenericRepository<ImpuestosProducto>, IImpuestosProductoServiceRepository
    {
        public ImpuestosProductoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
