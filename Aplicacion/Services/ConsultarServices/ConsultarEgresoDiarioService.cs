using Aplicacion.Request.Salidas;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using Infra.Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Services.ConsultarServices
{
    public class ConsultarEgresoDiarioService
    {
        readonly ObeliscoContext _context;
        readonly IUnitOfWork _unitOfWork;
        ConsultarEgresoDiarioResponse response;
        public ConsultarEgresoDiarioService(ObeliscoContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            response = new ConsultarEgresoDiarioResponse
            {
                Dfacturas = new List<DetallesFactura>()
            };
        }
        public ConsultarEgresoDiarioResponse Ejecutar(DateTime fecha, string tercero)
        {
            var DFacturas = (from df in _context.Set<DFactura>()
                             join p in _context.Set<Producto>()
                             on df.Referencia equals p.Referencia
                             join mf in _context.Set<MFactura>()
                             on df.MfacturaId equals mf.Id
                             join t in _context.Set<Terceros>()
                             on mf.TercerosId equals t.Id
                             where df.FechaFactura.Date == fecha.Date && t.Identificacion == tercero && mf.TipoMovimiento == "Venta"
                             select new
                             {
                                 Codigo = df.Referencia,
                                 Descripcion = p.Descripcion,
                                 CentroCosto = df.Bodega,
                                 Tercero = t.Identificacion,
                                 ValorTotal = df.PrecioTotal
                             }).ToList();

            var result = (from mf in _context.Set<MFactura>()
                          join t in _context.Set<Terceros>()
                          on mf.TercerosId equals t.Id
                          join tm in _context.Set<TipoMovimiento>()
                          on mf.TipoMovimientoId equals tm.Id
                          where t.Identificacion == tercero && mf.FechaFactura.Date == fecha.Date && mf.TipoMovimiento == "Venta"
                          select new
                          {
                              Nombre = t.Nombre + " " + t.Apellido,
                              NIT = t.Identificacion,
                              t.Celular,
                              t.Direccion,
                              Ciudad = "Valledupar",
                              FechaComprobante = mf.FechaFactura.Date,
                              Cheque = "100-019",
                              ValorTotal = mf.Total,
                              NombreMov = tm.Nombre,
                              Serial = "1000-A10",
                              NombreBanco = "CAJA GENERAL",
                              DFacturas
                          }).ToList();
            if (result[0] != null)
            {
                response.Nombre = result[0].Nombre;
                response.NIT = result[0].NIT;
                response.Ciudad = result[0].Ciudad;
                response.FechaComprobante = result[0].FechaComprobante.ToString("dd-MM-yyyy");
                response.ValorTotal = result[0].ValorTotal.ToString("C2");
                response.Celular = result[0].Celular;
                response.Direccion = result[0].Direccion;
                response.NombreBanco = result[0].NombreBanco;
                foreach (var item in result[0].DFacturas)
                {
                    DetallesFactura detalle = new DetallesFactura
                    {
                        Codigo = item.Codigo,
                        Descripcion = item.Descripcion,
                        CentroCosto = item.CentroCosto,
                        Tercero = item.Tercero,
                        ValorTotal = item.ValorTotal.ToString("C2")
                    };
                    response.Dfacturas.Add(detalle);
                }
            }
            response.Observaciones = "";
            response.NombreMov = "EGRESO DIARIO";
            response.Serial = "EG-01010-" + tercero;
            return response;
        }
    }
}