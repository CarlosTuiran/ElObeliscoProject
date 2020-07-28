using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class NominaServiceRepository : GenericRepository<Nomina>, INominaServiceRepository
    {
        public NominaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
