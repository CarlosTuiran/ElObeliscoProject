using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class UsuarioServiceRepository : GenericRepository<Usuario>, IUsuarioServiceRepository
    {
        public UsuarioServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
