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
        public async Task<IActionResult> GetMFactura([FromRoute] int id)
        {
            MFactura factura = await _context.MFactura.SingleOrDefaultAsync(t => t.Id == id);
            if (factura== null)
                return NotFound();
            return Ok(factura);
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
    }
}
