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
    public class MarcaController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly CrearMarcaService _crearService;        
        private readonly ActualizarMarcaService _actualizarService;
        private readonly EliminarMarcaService _eliminarService;

        public MarcaController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearMarcaService(_unitOfWork);
            _actualizarService = new ActualizarMarcaService(_unitOfWork);
            _eliminarService = new EliminarMarcaService(_unitOfWork);
        }

        [HttpGet]
        public IEnumerable<Marca> GetMarcas()
        {
            return _context.Marca;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarca([FromRoute] int id)
        {
            Marca marca = await _context.Marca.SingleOrDefaultAsync(t => t.Id == id);
            if (marca == null)
                return NotFound();
            return Ok(marca);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarca([FromBody] CrearMarcaRequest marca)
        {
            var rta = _crearService.Ejecutar(marca);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMarca", new { marca.Id }, marca);
            }
            return BadRequest(rta.Message);
        }


        [HttpPut]
        public async Task<IActionResult> PutMarca([FromBody] ActualizarMarcaRequest marca)
        {
            var rta = _actualizarService.Ejecutar(marca);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMarca", new { marca.Id }, marca);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca([FromRoute] int id)
        {
            var rta = _eliminarService.Ejecutar(id);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMarca", new { Id = id });
            }
            return BadRequest(rta.Message);
        }
    }
}
