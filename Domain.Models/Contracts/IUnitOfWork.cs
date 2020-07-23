using Domain.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IDFacturaServiceRepository DFacturaServiceRepository { get; }
        IMFacturaServiceRepository MFacturaServiceRepository { get; }
        IProductoServiceRepository ProductoServiceRepository { get; }
        IInventarioServiceRepository InventarioServiceRepository { get; }
       
        int Commit();
    }
}
