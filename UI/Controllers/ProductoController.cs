using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Request;
using Aplicacion.Services.ActualizarServices;
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
        private UnitOfWork _unitOfWork;
        private CrearProductoService _service;
        private ActualizarProductoService _actualizarService;
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
        public async Task<IActionResult> GetProducto([FromRoute] string id)
        {
            Producto producto = await _context.Producto.SingleOrDefaultAsync(t => t.Referencia == id);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto([FromRoute] string id, [FromBody] ActualizarProductoRequest producto)
        {
            _actualizarService = new ActualizarProductoService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(producto);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProducto", new { id = producto.Referencia }, producto);
            }
            return BadRequest(rta.Message);
        }
        
        //public IEnumerable<top10Producto> top10Productos()
        //public async Task<ActionResult<top10Producto>> top10Productos()
        [HttpGet("Top10Productos")]
        public object Top10Productos()
        {
            var result =  (from p in _context.Set<Producto>() 
                         join i in  _context.Set<Inventario>() 
                         on p.Referencia equals i.Referencia 
                         select new 
                         { 
                             Descripcion = p.Descripcion, 
                             Cantidad = i.Cantidad,
                         }).OrderByDescending(i => i.Cantidad).Take(10).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        // Para la lista del costo total de los productos en el momento, se puede colocar los 10 o 20 aunque aja no c decides xD 
        [HttpGet("CostoTotalProductos")]
        public object CostoTotalProductos()
        {
            var result = (from p in _context.Set<Producto>()
                          join i in _context.Set<Inventario>()
                          on p.Referencia equals i.Referencia
                          select new
                          {
                              Descripcion = p.Descripcion,
                              CostoTotal = i.Cantidad * p.Costo,
                          }).OrderByDescending(i => i.CostoTotal).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }



    }
}