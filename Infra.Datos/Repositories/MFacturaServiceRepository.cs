using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class MFacturaServiceRepository : GenericRepository<MFactura>, IMFacturaServiceRepository
    {
        public MFacturaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
