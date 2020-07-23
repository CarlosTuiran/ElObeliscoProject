using Domain.Models.Contracts;
using Domain.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        
        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }

        //Repositorios Por aca

        public IDFacturaServiceRepository DFacturaServiceRepository => throw new NotImplementedException();

        public IMFacturaServiceRepository MFacturaServiceRepository => throw new NotImplementedException();

        public IProductoServiceRepository ProductoServiceRepository => throw new NotImplementedException();

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
