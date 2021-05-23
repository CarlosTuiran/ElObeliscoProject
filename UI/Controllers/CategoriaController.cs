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
    public class CategoriaController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly CrearCategoriaService _crearService;
        private readonly ActualizarCategoriaService _actualizarService;
        private readonly EliminarCategoriaService _eliminarService;

        public CategoriaController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearCategoriaService(_unitOfWork);
            _actualizarService = new ActualizarCategoriaService(_unitOfWork);
            _eliminarService = new EliminarCategoriaService(_unitOfWork);
        }

        [HttpGet]
        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categoria;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria([FromRoute] int id)
        {
            Categoria categoria = await _context.Categoria.SingleOrDefaultAsync(t => t.Id == id);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CrearCategoriaRequest categoria)
        {
            var rta = _crearService.Ejecutar(categoria);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCategoria", new { categoria.Id }, categoria);
            }
            return BadRequest(rta.Message);
        }


        [HttpPut]
        public async Task<IActionResult> PutCategoria([FromBody] ActualizarCategoriaRequest categoria)
        {
            var rta = _actualizarService.Ejecutar(categoria);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCategoria", new { categoria.Id }, categoria);
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
                return CreatedAtAction("GetCategoria", new { id });
            }
            return BadRequest(rta.Message);
        }
    }
}
