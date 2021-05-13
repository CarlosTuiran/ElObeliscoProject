using Domain.Models.Contracts;
using Domain.Models.Entities;
using Infra.Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aplicacion.Services.ConsultarServices
{
    public class ConsultarFacturaCompra
    {
        readonly ObeliscoContext _context;
        readonly IUnitOfWork _unitOfWork;

        public ConsultarFacturaCompra(ObeliscoContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }



        public Object Ejecutar(int idMFactura)
        {
            var dFacturas = _unitOfWork.DFacturaServiceRepository.GetAll().Where(t => t.MfacturaId == idMFactura);

            var result = (from mf in _context.Set<MFactura>()
                          join df in _context.Set<DFactura>()
                          on mf.Id equals df.MfacturaId
                          join p in _context.Set<Producto>()
                          on df.Referencia equals p.Referencia
                          join e in _context.Set<Empleado>()
                          on mf.EmpleadoId equals e.Id
                          join t in _context.Set<Terceros>()
                          on mf.TercerosId equals t.Id
                          where mf.Id == idMFactura
                          select new
                          {
                              Tercero = t.Nombre + " " + t.Apellido,
                              t.Nit,
                              t.Celular,
                              t.Direccion,
                              Ciudad = "Valledupar",
                              mf.FechaFactura,
                              FechaVencimiento = mf.FechaFactura,
                              dFacturas
                          }).ToList();
            return result;

        }
    }
}
