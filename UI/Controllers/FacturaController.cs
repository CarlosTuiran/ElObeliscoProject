using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Request;
using Aplicacion.Services.CrearServices;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private CrearFacturasService _service;
        private UnitOfWork _unitOfWork;

        public FacturaController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }
        [HttpGet]
        public Object GetMFacturas()
        {
            var result = (from f in _context.Set<MFactura>()
                          join e in _context.Set<Empleado>()
                          on f.EmpleadoId equals e.Id
                          join t in _context.Set<Terceros>()
                          on f.TercerosId equals t.Id
                          join tp in _context.Set<TipoMovimiento>()
                          on f.TipoMovimientoId equals tp.Id
                          select new
                          {
                              MFacturaId = f.Id,
                              EmpleadoId = e.Nombres,
                              TercerosId = t.Nombre,
                              TipoMovimientoId = tp.Nombre,
                              FechaPago = f.FechaPago,
                              SubTotal = f.SubTotal,
                              ValorDevolucion = f.ValorDevolucion,
                              Descuento = f.Descuento,
                              IVA = f.IVA,
                              Abono = f.Abono,
                              EstadoFactura = f.EstadoFactura

                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        [HttpGet("{id}")]
        public Object GetDFactura([FromRoute] int id)
        {
            var factura = _context.MFactura.SingleOrDefault(t => t.Id == id);
            if (factura == null)
                return NotFound();
            var result = (from mf in _context.Set<MFactura>()
                          join df in _context.Set<DFactura>()
                          on mf.Id equals df.MfacturaId
                          join p in _context.Set<Producto>()
                          on df.Referencia equals p.Referencia
                          join e in _context.Set<Empleado>()
                          on mf.EmpleadoId equals e.Id
                          join t in _context.Set<Terceros>()
                          on mf.TercerosId equals t.Id
                          where df.MfacturaId == id
                          select new
                          {
                              EmpleadoId = e.Nombres,
                              TercerosId = mf.TercerosId,
                              Referencia = p.Descripcion,
                              idPromocion = df.idPromocion, //* Agregar Promocion Nombre
                              Bodega = df.Bodega, //* Bodega tambien
                              Cantidad = df.Cantidad,
                              PrecioUnitario = df.PrecioUnitario,
                              PrecioTotal = df.PrecioTotal,
                              FechaFactura = df.FechaFactura
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFacturas([FromBody] CrearMFacturaRequest request)
        {
            _service = new CrearFacturasService(_unitOfWork);
            var rta = _service.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetFactura", new { id = request.idMfactura }, request);
            }
            return BadRequest(rta.Message);
        }
        [HttpPost("preCreateFacturas")]
        public async Task<IActionResult> PreCreateFactura([FromBody] CrearMFacturaRequest request)
        {
            _service = new CrearFacturasService(_unitOfWork);
            var rta = _service.PreEjecutar(request);
            if (rta.isOkSubTotal())
            {
                await _context.SaveChangesAsync();
                return Ok(rta);
            }
            return BadRequest(rta.Message);
        }
        //?Card comparacion de Total ventas de ultimo mes 
        [HttpGet("VentasMensuales")]
        public object VentasMensuales()
        {
            var result = (from mf in _context.Set<MFactura>()
                          join t in _context.Set<Tiempo>()
                          on mf.FechaFactura equals t.Fecha
                          where mf.TipoMovimiento == "Venta" && 
                                (t.Anio == DateTime.Now.Year.ToString() && t.Mes_Anio == DateTime.Now.Month) || 
                                (t.Mes_Anio == DateTime.Now.AddMonths(-1).Month)
                          group mf by new { t.Mes_Descripcion, t.Mes_Anio } into newGroup1
                          select new
                          {
                              Mes_Descripcion = newGroup1.Key.Mes_Descripcion,
                              Total = newGroup1.Sum(c => c.Total),
                              Mes = newGroup1.Key.Mes_Anio
                          }).OrderBy(x => x.Mes).ToList();
            var TotalPasadoMes = !result.Any(x => x.Mes_Descripcion == DateTime.Now.AddMonths(-1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"))) ? 0 : result[0].Total;
            var TotalPresenteMes = !result.Any(x => x.Mes_Descripcion == DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"))) ? 0 : result[1].Total;
            var percentValue = Math.Abs((TotalPresenteMes - TotalPasadoMes) / TotalPasadoMes);
            bool isIncrease=true;
            if (TotalPasadoMes>TotalPresenteMes) {
                //Es decremento
                isIncrease=false;                
            }            
            string title = "Total Ventas";
            double value=TotalPresenteMes;
            string color = "red";
            bool isCurrency=true;
            string duration="desde el Anterior Mes";
            string icon="shopping_cart";
            /*var cardRta = (from r in result
                           select new
                           {
                               title,
                               value,
                               color,
                               isCurrency,
                               duration,
                               isIncrease,
                               percentValue
                           }
                           ).Take(1).ToList();*/
            var cardRta = (title, value, color, isCurrency, duration, isIncrease, percentValue,icon);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(cardRta, Newtonsoft.Json.Formatting.Indented);
            return cardRta;
        }
        //
        [HttpGet("TotalFacturasVentas")]
        public object TotalFacturasVentas()
        {
            var result = (from mf in _context.Set<MFactura>()
                          where mf.TipoMovimiento == "Venta"
                          select new
                          {
                              IdMfactura = mf.Id
                          }).ToList();
            var sum = result.Select(a => a.IdMfactura).Count();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(sum, Newtonsoft.Json.Formatting.Indented);
            return sum;
        }


        // Retorna el total de ordenes del mes para la tarjeta
        [HttpGet("TotalOrdenes")]
        public object TotalOrdenes()
        {
            // Realizar consulta count afuera de la consulta principal
            var result = (from mf in _context.Set<MFactura>()
                          join t in _context.Set<Tiempo>()
                          on mf.FechaFactura equals t.Fecha
                          where mf.TipoMovimiento == "Venta" &&
                                (t.Anio == DateTime.Now.Year.ToString() 
                                && t.Mes_Anio == DateTime.Now.Month) ||
                                (t.Mes_Anio == DateTime.Now.AddMonths(-1).Month)
                          group mf by new { t.Mes_Descripcion, t.Mes_Anio } into newGroup1
                          select new
                          {
                              Mes_Descripcion = newGroup1.Key.Mes_Descripcion,
                              Total = newGroup1.Count(),
                              Mes = newGroup1.Key.Mes_Anio
                          }).OrderBy(x => x.Mes).ToList();

            double TotalPasadoMes = !result.Any(x=>x.Mes_Descripcion == DateTime.Now.AddMonths(-1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")) ) ? 0 : result[0].Total;
            double TotalPresenteMes = !result.Any(x => x.Mes_Descripcion == DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"))) ? 0 : result[1].Total;
            var percentValue = Math.Abs((TotalPresenteMes - TotalPasadoMes) / TotalPasadoMes);
            bool isIncrease = true;
            if (TotalPasadoMes > TotalPresenteMes)
            {
                //Es decremento
                isIncrease = false;
            }
            string title = "Total Ordenes Mensuales";
            double value = TotalPresenteMes;
            string color = "purple";
            bool isCurrency = false;
            string duration = "desde el Anterior Mes";
            string icon="payments";

            /*var cardRta = (from r in result
                           select new
                           {
                               title,
                               value,
                               color,
                               isCurrency,
                               duration,
                               isIncrease,
                               percentValue
                           }
                           ).Take(1).ToList();*/
            var cardRta = (title, value, color, isCurrency, duration, isIncrease, percentValue, icon);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(cardRta, Newtonsoft.Json.Formatting.Indented);
            return cardRta;
        }



        // Retorna el promedio de ventas del mes para la tarjeta
        [HttpGet("AverageOrderValue")]
        public object AverageOrderValue()
        {
            var result = (from mf in _context.Set<MFactura>()
                          join t in _context.Set<Tiempo>()
                          on mf.FechaFactura equals t.Fecha
                          where mf.TipoMovimiento == "Venta" &&
                                (t.Anio == DateTime.Now.Year.ToString() && t.Mes_Anio == DateTime.Now.Month) ||
                                (t.Mes_Anio == DateTime.Now.AddMonths(-1).Month)
                          group mf by new { t.Mes_Descripcion, t.Mes_Anio } into newGroup1
                          select new
                          {
                              Mes_Descripcion = newGroup1.Key.Mes_Descripcion,
                              Total = newGroup1.Average(c => c.Total),
                              Mes = newGroup1.Key.Mes_Anio
                          }).OrderBy(x => x.Mes).ToList();

            var TotalPasadoMes = !result.Any(x => x.Mes_Descripcion == DateTime.Now.AddMonths(-1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"))) ? 0 : result[0].Total;
            var TotalPresenteMes = !result.Any(x => x.Mes_Descripcion == DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"))) ? 0 : result[1].Total;
            var percentValue = Math.Abs((TotalPresenteMes - TotalPasadoMes) / TotalPasadoMes);
            bool isIncrease = true;
            if (TotalPasadoMes > TotalPresenteMes)
            {
                //Es decremento
                isIncrease = false;
            }
            string title = "Promedio de ventas mensuales";
            double value = TotalPresenteMes;
            string color = "gold";
            bool isCurrency = true;
            string duration = "desde el Anterior Mes";
            string icon="monetization_on";
            /*var cardRta = (from r in result
                           select new
                           {
                               title,
                               value,
                               color,
                               isCurrency,
                               duration,
                               isIncrease,
                               percentValue
                           }
                           ).Take(1).ToList();*/

            var cardRta = (title,value,color,isCurrency,duration,isIncrease,percentValue, icon);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(cardRta, Newtonsoft.Json.Formatting.Indented);
            return cardRta;
        }

        [HttpGet("ConsultasCartas")]
        public object ConsultasCartas()
        {
            object ventasMensuales = VentasMensuales();
            object totalOrdenes = TotalOrdenes();            
            object averageOrderValue = AverageOrderValue();
            List<Object> cards = new List<Object>
            {
                totalOrdenes,
                ventasMensuales,
                averageOrderValue
            };
            return cards;
        }
    }
}