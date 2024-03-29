﻿using Domain.Models.Contracts;
using Domain.Models.Repositories;
using Infra.Datos.Repositories;
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

        private IDFacturaServiceRepository _dFacturaServiceRepository;
        public IDFacturaServiceRepository DFacturaServiceRepository { 
            get 
            {
                return _dFacturaServiceRepository ?? (_dFacturaServiceRepository= new DFacturaServiceRepository(_dbContext));
            } 
        }

        private IMFacturaServiceRepository _mFacturaServiceRepository;
        public IMFacturaServiceRepository MFacturaServiceRepository
        {
            get
            {
                return _mFacturaServiceRepository ?? (_mFacturaServiceRepository = new MFacturaServiceRepository(_dbContext));
            }
        }

        private IProductoServiceRepository _productoServiceRepository;
        public IProductoServiceRepository ProductoServiceRepository
        {
            get
            {
                return _productoServiceRepository ?? (_productoServiceRepository = new ProductoServiceRepository(_dbContext));
            }
        }

        private IInventarioServiceRepository _inventarioServiceRepository;
        public IInventarioServiceRepository InventarioServiceRepository
        {
            get
            {
                return _inventarioServiceRepository ?? (_inventarioServiceRepository = new InventarioServiceRepository(_dbContext));
            }
        }

        private IEmpleadoServiceRepository _empleadoServiceRepository;
        public IEmpleadoServiceRepository EmpleadoServiceRepository
        {
            get
            {
                return _empleadoServiceRepository ?? (_empleadoServiceRepository = new EmpleadoServiceRepository(_dbContext));
            }
        }

        private INominaServiceRepository _nominaServiceRepository;
        public INominaServiceRepository NominaServiceRepository
        {
            get
            {
                return _nominaServiceRepository ?? (_nominaServiceRepository = new NominaServiceRepository(_dbContext));
            }
        }

        private ITercerosServiceRepository _tercerosServiceRepository;
        public ITercerosServiceRepository TercerosServiceRepository
        {
            get
            {
                return _tercerosServiceRepository ?? (_tercerosServiceRepository = new TercerosServiceRepository(_dbContext));
            }
        }

        private ITipoMovimientoServiceRepository _tipoMovimientoServiceRepository;
        public ITipoMovimientoServiceRepository TipoMovimientoServiceRepository
        {
            get
            {
                return _tipoMovimientoServiceRepository ?? (_tipoMovimientoServiceRepository = new TipoMovimientoServiceRepository(_dbContext));
            }
        }
        private IUsuarioServiceRepository _usuarioServiceRepository;
        public IUsuarioServiceRepository UsuarioServiceRepository
        {
            get
            {
                return _usuarioServiceRepository ?? (_usuarioServiceRepository = new UsuarioServiceRepository(_dbContext));
            }
        }
        private ILiquidacionServiceRepository _liquidacionServiceRepository;
        public ILiquidacionServiceRepository LiquidacionServiceRepository
        {
            get
            {
                return _liquidacionServiceRepository ?? (_liquidacionServiceRepository = new LiquidacionServiceRepository(_dbContext));
            }
        }

        private ITiempoServiceRepository _tiempoServiceRepository;
        public ITiempoServiceRepository TiempoServiceRepository
        {
            get
            {
                return _tiempoServiceRepository ?? (_tiempoServiceRepository = new TiempoServiceRepository(_dbContext));
            }
        }

        private ITotalLiquidacionServiceRepository _totalLiquidacionServiceRepository;
        public ITotalLiquidacionServiceRepository TotalLiquidacionServiceRepository
        {
            get
            {
                return _totalLiquidacionServiceRepository ?? (_totalLiquidacionServiceRepository = new TotalLiquidacionServiceRepository(_dbContext));
            }
        }

        private IFormatoVentaServiceRepository _formatoVentaServiceRepository;
        public IFormatoVentaServiceRepository FormatoVentaServiceRepository
        {
            get
            {
                return _formatoVentaServiceRepository ?? (_formatoVentaServiceRepository = new FormatoVentaServiceRepository(_dbContext));
            }
        }

        private ICuentaServiceRepository _cuentaServiceRepository;
        public ICuentaServiceRepository CuentaServiceRepository
        {
            get
            {
                return _cuentaServiceRepository ?? (_cuentaServiceRepository = new CuentaServiceRepository(_dbContext));
            }
        }

        private IMarcaServiceRepository _marcaServiceRepository;
        public IMarcaServiceRepository MarcaServiceRepository
        {
            get
            {
                return _marcaServiceRepository ?? (_marcaServiceRepository = new MarcaServiceRepository(_dbContext));
            }
        }
        private ICategoriaServiceRepository _categoriaServiceRepository;
        public ICategoriaServiceRepository CategoriaServiceRepository
        {
            get
            {
                return _categoriaServiceRepository ?? (_categoriaServiceRepository = new CategoriaServiceRepository(_dbContext));
            }
        }
        private IImpuestoServiceRepository _impuestoServiceRepository;
        public IImpuestoServiceRepository ImpuestoServiceRepository
        {
            get
            {
                return _impuestoServiceRepository ?? (_impuestoServiceRepository = new ImpuestoServiceRepository(_dbContext));
            }
        }

        private IImpuestosProductoServiceRepository _impuestosProductoServiceRepository;
        public IImpuestosProductoServiceRepository ImpuestosProductoServiceRepository
        {
            get
            {
                return _impuestosProductoServiceRepository ?? (_impuestosProductoServiceRepository = new ImpuestosProductoServiceRepository(_dbContext));
            }
        }
        private ILibroContableServiceRepository _libroCOntableServiceRepository;
        public ILibroContableServiceRepository LibroContableServiceRepository
        {
            get
            {
                return _libroCOntableServiceRepository ?? (_libroCOntableServiceRepository = new LibroContableServiceRepository(_dbContext));
            }
        }
        private IParametrosServiceRepository _parametrosServiceRepository;
        public IParametrosServiceRepository ParametrosServiceRepository
        {
            get
            {
                return _parametrosServiceRepository ?? (_parametrosServiceRepository = new ParametrosServiceRepository(_dbContext));
            }
        }
        private IBodegaServiceRepository _bodegaServiceRepository;
        public IBodegaServiceRepository BodegaServiceRepository
        {
            get
            {
                return _bodegaServiceRepository ?? (_bodegaServiceRepository = new BodegaServiceRepository(_dbContext));
            }
        }
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
