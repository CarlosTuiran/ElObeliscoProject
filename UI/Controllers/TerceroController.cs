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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTercero([FromRoute] string id)
        {
            Terceros terceros = await _context.Terceros.SingleOrDefaultAsync(t => t.Nit == id);
            if (terceros == null)
                return NotFound();
            _context.Terceros.Remove(terceros);
            await _context.SaveChangesAsync();
            return Ok(terceros);
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
    }
}
