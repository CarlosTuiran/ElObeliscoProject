using Domain.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IDFacturaServiceRepository DFacturaServiceRepository { get; }
        IEmpleadoServiceRepository EmpleadoServiceRepository { get; }
        IInventarioServiceRepository InventarioServiceRepository { get; }
        IMFacturaServiceRepository MFacturaServiceRepository { get; }
        INominaServiceRepository NominaServiceRepository { get; }
        IProductoServiceRepository ProductoServiceRepository { get; }
        ITercerosServiceRepository TercerosServiceRepository { get; }
        ITipoMovimientoServiceRepository TipoMovimientoServiceRepository { get; }

        int Commit();
    }
}
