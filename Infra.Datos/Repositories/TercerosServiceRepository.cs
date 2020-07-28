using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class TercerosServiceRepository : GenericRepository<Terceros>, ITercerosServiceRepository
    {
        public TercerosServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
