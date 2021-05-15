using Domain.Models.Contracts;
using Domain.Models.Entities;
using Infra.Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Aplicacion.Request.Salidas;

namespace Aplicacion.Services.ConsultarServices
{
    public class ConsultarFacturaCompraService
    {
        readonly ObeliscoContext _context;
        readonly IUnitOfWork _unitOfWork;
        ConsultarFacturaCompraResponse response;
        public ConsultarFacturaCompraService(ObeliscoContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            response = new ConsultarFacturaCompraResponse();
            response.Dfacturas = new List<DetallesFactura>();
        }



        public ConsultarFacturaCompraResponse Ejecutar(int idMFactura)
        {
            var DFacturas = (from df in _context.Set<DFactura>()
                             join p in _context.Set<Producto>()
                             on df.Referencia equals p.Referencia
                              where df.MfacturaId == idMFactura
                              select new
                              {
                                  Codigo = df.Referencia,
                                  Descripcion = p.Descripcion,
                                  Unidad = df.FormatoProducto,
                                  ValorUnitario = df.PrecioUnitario,
                                  p.IVA,
                                  Cantidad = df.Cantidad,
                                  ValorTotal = df.PrecioTotal
                              }).ToList();

            var result = (from mf in _context.Set<MFactura>()
                          join t in _context.Set<Terceros>()
                          on mf.TercerosId equals t.Id
                          join tm in _context.Set<TipoMovimiento>()
                          on mf.TipoMovimientoId equals tm.Id
                          where mf.Id == idMFactura
                          select new
                          {
                              Nombre = t.Nombre + " " + t.Apellido,
                              NIT = t.Nit,
                              t.Celular,
                              t.Direccion,
                              Ciudad = "Valledupar",
                              FechaComprobante = mf.FechaFactura.Date,
                              FechaVencimiento = mf.FechaFactura.Date,
                              ValorBruto = mf.SubTotal,
                              Iva = mf.IVA,
                              ValorTotal = mf.Total,
                              CondicionPago = tm.Nombre,
                              DFacturas
                          }).ToList();
            
            response.Nombre = result[0].Nombre;
            response.NIT = result[0].NIT;
            response.Ciudad = result[0].Ciudad;
            response.FechaComprobante = result[0].FechaComprobante.ToString("dd-MM-yyyy");
            response.FechaVencimiento = result[0].FechaVencimiento.ToString("dd-MM-yyyy");
            response.ValorBruto = result[0].ValorBruto.ToString("C2");
            response.Iva = result[0].Iva.ToString("C2");
            response.ValorTotal = result[0].ValorTotal.ToString("C2");
            response.CondicionPago = result[0].CondicionPago.ToString();
            response.Celular = result[0].Celular;
            response.Direccion = result[0].Direccion;
            foreach (var item in result[0].DFacturas)
            {
                DetallesFactura detalle = new DetallesFactura();
                detalle.Cantidad = item.Cantidad;
                detalle.Codigo = item.Codigo;
                detalle.Descripcion = item.Descripcion;
                detalle.Unidad = item.Unidad;
                detalle.Iva = item.IVA;
                detalle.ValorUnitario = item.ValorUnitario.ToString("C2");
                detalle.ValorTotal = item.ValorTotal.ToString("C2");;
                response.Dfacturas.Add(detalle);
            }
            response.NombreMov="Factura Compra";
            response.Serial="SR-2021-" + idMFactura.ToString();
            return response;

        }
    }
}
