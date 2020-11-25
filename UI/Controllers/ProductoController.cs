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
        private CrearProductoService _service;
        private UnitOfWork _unitOfWork;
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
        
        [HttpGet]
        public List<top10Producto> top10Productos()
        {
            /*var rta = _context.Producto
            .FromSqlRaw("select p.Descripcion, i.Cantidad from Producto p inner join Inventario i on i.Referencia = p.Referencia")
            .ToList();*/
            
            /*var query = from p in _context.Set<Producto>()
            join i in _context.Set<Inventario>()
                on p.Referencia equals i.Referencia
            select new { p.Descripcion, i.Cantidad };*/

            var lista=new List<top10Producto>();
            var productos=  _context.Inventario.Include(i=>i.Productos);
            foreach (var i in productos)
            {
                foreach (var p in i.Productos)
                {
                    var item=new top10Producto();
                    item.descripcion=p.Descripcion;
                    item.cantidad=i.Cantidad;
                    lista.Add(item);
                }
            }
            
            /*foreach (var item in rta)
            {
                top10Producto row = new top10Producto
                {
                    descripcion = item.descripcion.ToString(),
                    cantidad = int.Parse(item[1].ToString())
                };    
            }*/
            
            //return query.ToList();
            return lista;
        }


        public class top10Producto
        {
            public string descripcion;
            public int cantidad ;
        }
    }
}