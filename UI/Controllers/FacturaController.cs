using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Request;
using Aplicacion.Services.CrearServices;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}