using Aplicacion.Request;
using Aplicacion.Services.ActualizarServices;
using Aplicacion.Services.CrearServices;
using Aplicacion.Services.EliminarServices;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpuestoController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly CrearImpuestoService _crearService;
        private readonly ActualizarImpuestoService _actualizarService;
        private readonly EliminarImpuestoService _eliminarService;

        public ImpuestoController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearImpuestoService(_unitOfWork);
            _actualizarService = new ActualizarImpuestoService(_unitOfWork);
            _eliminarService = new EliminarImpuestoService(_unitOfWork);
        }
        [HttpGet]
        public IEnumerable<Impuesto> GetImpuestos()
        {
            return _context.Impuesto;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImpuesto([FromRoute] int id)
        {
            Impuesto impuesto = await _context.Impuesto.SingleOrDefaultAsync(t => t.Id == id);
            if (impuesto == null)
                return NotFound();
            return Ok(impuesto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImpuesto([FromBody] CrearImpuestoRequest impuesto)
        {
            var rta = _crearService.Ejecutar(impuesto);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetImpuesto", new { impuesto.Id }, impuesto);
            }
            return BadRequest(rta.Message);
        }


        [HttpPut]
        public async Task<IActionResult> PutImpuesto([FromBody] ActualizarImpuestoRequest impuesto)
        {
            var rta = _actualizarService.Ejecutar(impuesto);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetImpuesto", new { impuesto.Id }, impuesto);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria([FromRoute] int id)
        {
            var rta = _eliminarService.Ejecutar(id);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetImpuesto", new { id });
            }
            return BadRequest(rta.Message);
        }
    }
}
