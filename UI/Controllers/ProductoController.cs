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
    public class ProductoController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private CrearProductoService _service;
        private UnitOfWork _unitOfWork;

        public ProductoController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Producto> GetProductos()
        {
            return _context.Producto;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductos([FromRoute] string referencia)
        {
            Producto producto = await _context.Producto.SingleOrDefaultAsync(t => t.Referencia == referencia);
            if (producto == null)
                return NotFound();
            return Ok(producto);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] CrearProductoRequest producto)
        {
            _service = new CrearProductoService(_unitOfWork);
            var rta = _service.Ejecutar(producto);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProducto", new { id = producto.Referencia }, producto);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto([FromRoute] string referencia)
        {
            Producto producto = await _context.Producto.SingleOrDefaultAsync(t => t.Referencia == referencia);
            if (producto == null)
                return NotFound();
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
        }
    }
}
