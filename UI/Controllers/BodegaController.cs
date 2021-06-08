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
    public class BodegaController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private readonly CrearBodegaService _crearService;
        private readonly ActualizarBodegaService _actualizarService;
        private readonly EliminarBodegaService _eliminarService;

        public BodegaController(ObeliscoContext context)
        {
            _context = context;
            UnitOfWork _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearBodegaService(_unitOfWork);
            _actualizarService = new ActualizarBodegaService(_unitOfWork);
            _eliminarService = new EliminarBodegaService(_unitOfWork);
        }
        [HttpGet]
        public IEnumerable<Bodega> GetBodegas()
        {
            return _context.Bodega;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBodega([FromRoute] int id)
        {
            Bodega bodega = await _context.Bodega.SingleOrDefaultAsync(t => t.Id == id);
            if (bodega == null)
                return NotFound();
            return Ok(bodega);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBodega([FromBody] BodegaRequest bodega)
        {
            var rta = _crearService.Ejecutar(bodega);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBodega", new { bodega.Id }, bodega);
            }
            return BadRequest(rta.Message);
        }


        [HttpPut]
        public async Task<IActionResult> PutBodega([FromBody] BodegaRequest bodega)
        {
            var rta = _actualizarService.Ejecutar(bodega);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBodega", new { bodega.Id }, bodega);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodega([FromRoute] int id)
        {
            var rta = _eliminarService.Ejecutar(id);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBodega", new { id });
            }
            return BadRequest(rta.Message);
        }
    }
}
