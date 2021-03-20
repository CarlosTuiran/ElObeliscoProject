using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Request;
using Aplicacion.Services.CrearServices;
using Aplicacion.Services.ActualizarServices;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Services.EliminarServices;

namespace UI.InterfazWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private CrearTerceroService _service;
        private UnitOfWork _unitOfWork;
        private ActualizarTerceroService _actualizarService;
        private EliminarTerceroService _eliminarService;

        public TerceroController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Terceros> GetTerceros()
        {
            return _context.Terceros;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTercero([FromRoute] string id)
        {
            Terceros terceros = await _context.Terceros.SingleOrDefaultAsync(t => t.Nit == id);
            if (terceros == null)
                return NotFound();
            return Ok(terceros);
        }
        /*public async Task<ActionResult<IEnumerable<Usuario>>> getUsuarios()
        {
            var data = await _context.Usuario.ToListAsync();
            return Ok(data);
        }*/

        [HttpPost]
        public async Task<IActionResult> CreateTercero([FromBody] CrearTerceroRequest tercero)
        {
            _service = new CrearTerceroService(_unitOfWork);
            var rta = _service.Ejecutar(tercero);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTercero", new { id = tercero.Nit }, tercero);
            }
            return BadRequest(rta.Message);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTercero([FromRoute] string id, [FromBody] ActualizarTerceroRequest tercero)
        {
            _actualizarService = new ActualizarTerceroService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(tercero);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTercero", new { id = tercero.Nit }, tercero);
            }
            return BadRequest(rta.Message);
        }

        [HttpPut("DeleteTercero/{id}")]
        public async Task<IActionResult> DeleteTercero([FromRoute] string id)
        {
            EliminarTerceroRequest terceroRequest = new EliminarTerceroRequest();
            terceroRequest.Nit = id;
            _eliminarService = new EliminarTerceroService(_unitOfWork);
            var rta = _eliminarService.Ejecutar(terceroRequest);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEmpleado", new { id = terceroRequest.Nit }, terceroRequest);
            }
            return BadRequest(rta.Message);
        }
        //? Top 10 Clientes
        [HttpGet("Top10Clientes")]
        public object Top10Clientes()
        {
            var result =  (from t in _context.Set<Terceros>()
                           join mf in _context.Set<MFactura>()
                           on t.Id equals mf.TercerosId
                           join df in _context.Set<DFactura>()
                           on mf.Id equals df.MfacturaId
                           where mf.TipoMovimiento == "Venta" && t.TipoTercero == "Cliente"
                           group mf by new { t.Nit, t.Nombre, t.Apellido } into newGroup1
                           select new
                           {
                               Nit = newGroup1.Key.Nit,
                               Nombre = newGroup1.Key.Nombre + " " + newGroup1.Key.Apellido,
                               Total = newGroup1.Sum(c => c.Total)
                           }).OrderByDescending(i => i.Total).Take(10).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        //? Top 10 Proveedores
        
        [HttpGet("Top10Proveedores")]
        public object Top10Proveedores()
        {
            var result = (from t in _context.Set<Terceros>()
                          join mf in _context.Set<MFactura>()
                          on t.Id equals mf.TercerosId
                          join df in _context.Set<DFactura>()
                          on mf.Id equals df.MfacturaId
                          where mf.TipoMovimiento == "Compra" && t.TipoTercero == "Proveedor"
                          group mf by new { t.Nit, t.Nombre, t.Apellido } into newGroup1
                          select new
                          {
                              Nit = newGroup1.Key.Nit,
                              Nombre = newGroup1.Key.Nombre + " " + newGroup1.Key.Apellido,
                              Total = newGroup1.Sum(c => c.Total)
                          }).OrderByDescending(i => i.Total).Take(10).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
    }
}
