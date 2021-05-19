using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class MarcaServiceRepository : GenericRepository<Marca>, IMarcaServiceRepository
    {
        public MarcaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
