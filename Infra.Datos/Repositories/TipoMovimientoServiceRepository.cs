using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class TipoMovimientoServiceRepository : GenericRepository<TipoMovimiento>, ITipoMovimientoServiceRepository
    {
        public TipoMovimientoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
