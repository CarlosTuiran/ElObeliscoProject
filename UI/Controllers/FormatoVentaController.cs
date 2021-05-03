using Aplicacion.Request;
using Aplicacion.Services.CrearServices;
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
    public class FormatoVentaController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly CrearFormatoVentaService _service;

        public FormatoVentaController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _service = new CrearFormatoVentaService(_unitOfWork);
        }

        [HttpGet]
        public IEnumerable<FormatoVenta> GetFormatosVenta()
        {
            return _context.FormatoVenta;
        }
        [HttpGet("GetFormatos/{id}")]
        public async Task<IEnumerable<FormatoVenta>> GetFormatos([FromRoute] string id)
        {
            Producto producto = await _context.Producto.SingleOrDefaultAsync(t => t.Referencia == id);
            FormatoVenta formatoVenta = await _context.FormatoVenta.SingleOrDefaultAsync(t => t.Nombre == producto.FormatoVenta);
            return _context.FormatoVenta.Where(t => t.Metrica == formatoVenta.Metrica);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormatoVenta([FromRoute] int id)
        {
            FormatoVenta formatoVenta = await _context.FormatoVenta.SingleOrDefaultAsync(t => t.Id == id);
            if (formatoVenta == null)
                return NotFound();
            return Ok(formatoVenta);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFormatoVenta([FromBody] CrearFormatoVentaRequest formato)
        {
            var rta = _service.Ejecutar(formato);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(" GetFormatoVenta", new { id = formato.Id }, formato);
            }
            return BadRequest(rta.Message);
        }
    }
}
