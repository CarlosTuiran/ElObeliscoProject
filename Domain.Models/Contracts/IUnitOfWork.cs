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
        IEmpleadoServiceRepository EmpleadoServiceRepository { get; }
        INominaServiceRepository NominaServiceRepository { get; }
        ITercerosServiceRepository TercerosServiceRepository { get; }
        ITipoMovimientoServiceRepository TipoMovimientoServiceRepository { get; }
        IUsuarioServiceRepository UsuarioServiceRepository { get; }
        ILiquidacionServiceRepository LiquidacionServiceRepository { get; }
        ITiempoServiceRepository TiempoServiceRepository { get; }
        ITotalLiquidacionServiceRepository TotalLiquidacionServiceRepository { get; }

        int Commit();
    }
}
