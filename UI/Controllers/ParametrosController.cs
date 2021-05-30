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
    public class ParametrosController:Controller
    {
        private readonly ObeliscoContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly CrearParametrosService _crearService;
        private readonly ActualizarParametrosService _actualizarService;
        private readonly EliminarParametrosService _eliminarService;
        public ParametrosController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearParametrosService(_unitOfWork);
            _actualizarService = new ActualizarParametrosService(_unitOfWork);
            _eliminarService = new EliminarParametrosService(_unitOfWork);
        }
        [HttpGet]
        public IEnumerable<Parametros> GetParametross()
        {
            return _context.Parametros;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParametros([FromRoute] int id)
        {
            Parametros Parametros = await _context.Parametros.SingleOrDefaultAsync(t => t.Id == id);
            if (Parametros == null)
                return NotFound();
            return Ok(Parametros);
        }
        [HttpPost]
        public async Task<IActionResult> CreateParametros([FromBody] CrearParametrosRequest ParametrosRequest)
        {
            var rta = _crearService.Ejecutar(ParametrosRequest);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetParametros", new { Id = ParametrosRequest.Descripcion }, ParametrosRequest);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametros([FromRoute] int id, [FromBody] ActualizarParametrosRequest ParametrosRequest)
        {
            var rta = _actualizarService.Ejecutar(ParametrosRequest);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetParametros", new { id = ParametrosRequest.Id }, ParametrosRequest);
            }
            return BadRequest(rta.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametros([FromRoute] int id)
        {
            var rta = _eliminarService.Ejecutar(id);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetParametros", new { Id = id });
            }
            return BadRequest(rta.Message);
        }
    }
}
