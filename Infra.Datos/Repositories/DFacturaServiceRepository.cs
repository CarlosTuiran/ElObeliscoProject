using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class DFacturaServiceRepository : GenericRepository<DFactura>, IDFacturaServiceRepository
    {
        public DFacturaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
