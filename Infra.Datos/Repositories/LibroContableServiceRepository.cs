using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class LibroContableServiceRepository : GenericRepository<LibroContable>, ILibroContableServiceRepository
    {
        public LibroContableServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
