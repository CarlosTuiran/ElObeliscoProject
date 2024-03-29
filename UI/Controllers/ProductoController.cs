﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Request;
using Aplicacion.Services.ActualizarServices;
using Aplicacion.Services.CrearServices;
using Aplicacion.Services.EliminarServices;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
        private EliminarProductoService _eliminarService;
        CultureInfo provider = CultureInfo.InvariantCulture;

        public ProductoController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public object GetProductos()
        {
            var result = (from p in _context.Set<Producto>()
                          join m in _context.Set<Marca>()
                          on p.IdMarca equals m.Id
                          join c in _context.Set<Categoria>()
                          on p.IdCategoria equals c.Id
                          join t in _context.Set<Terceros>()
                          on p.IdProveedor equals t.Identificacion
                          select new
                          {
                              referencia = p.Referencia,
                              descripcion = p.Descripcion,
                              formatoVenta = p.FormatoVenta,
                              idMarca = m.Nombre,
                              idCategoria = c.Nombre,
                              idProveedor = t.Nombre+" "+t.Apellido,
                              fabrica = p.Fabrica,
                              costo = p.Costo,
                              precioVenta = p.PrecioVenta,
                              fechaRegistro = p.FechaRegistro,
                              cantidadMinima = p.CantidadMinima
                          }).ToList();
            return result;
        }

        [HttpGet("{id}")]
        public object GetProducto([FromRoute] string id)
        {
            var lista = _context.ImpuestosProducto.Where(i=> i.IdProducto == id).Select(i=> i.IdImpuesto).ToArray();
            var result = (from p in _context.Set<Producto>()
                          join m in _context.Set<Marca>()
                          on p.IdMarca equals m.Id
                          join c in _context.Set<Categoria>()
                          on p.IdCategoria equals c.Id
                          join t in _context.Set<Terceros>()
                          on p.IdProveedor equals t.Identificacion
                          where p.Referencia == id
                          select new
                          {
                              referencia = p.Referencia,
                              descripcion = p.Descripcion,
                              formatoVenta = p.FormatoVenta,
                              idMarca = m.Id,
                              idCategoria = c.Id,
                              idProveedor = t.Identificacion,
                              fabrica = p.Fabrica,
                              costo = p.Costo,
                              idImpuestos = lista,
                              precioVenta = p.PrecioVenta,
                              fechaRegistro = p.FechaRegistro,
                              cantidadMinima = p.CantidadMinima
                          }).ToList();
            return result;
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

        [HttpPut("DeleteProducto/{id}")]
        public async Task<IActionResult> DeleteProducto([FromRoute] string id)
        {
            EliminarProductoRequest productoRequest = new EliminarProductoRequest();
            productoRequest.Referencia = id;
            _eliminarService = new EliminarProductoService(_unitOfWork);
            var rta = _eliminarService.Ejecutar(productoRequest);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEmpleado", new { id = productoRequest.Referencia }, productoRequest);
            }
            return BadRequest(rta.Message);
        }

        [HttpGet("Top10VentaProductos")]
        public object Top10VentaProductos()
        {
            var result = (from p in _context.Set<Producto>()
                          join i in _context.Set<Inventario>()
                          on p.Referencia equals i.Referencia
                          join df in _context.Set<DFactura>()
                          on p.Referencia equals df.Referencia
                          join mf in _context.Set<MFactura>()
                          on df.MfacturaId equals mf.Id
                          where mf.TipoMovimiento == "Venta"
                          group df by new { df.Referencia, p.Descripcion } into newGroup1
                          select new 
                          {
                              Referencia = newGroup1.Key.Referencia,
                              Descripcion = newGroup1.Key.Descripcion,
                              Total = newGroup1.Sum(c => c.Cantidad)
                          }).OrderByDescending(i => i.Total).Take(10).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        } 
        //? TopVentaProductos que mas venden intervalo
        [HttpGet("Top10VentasProductosInterval/{fechaInicio}/{fechaFin}")]
        public object Top10VentasProductosInterval([FromRoute] string fechaInicio,[FromRoute] string fechaFin )
        {
            string format="ddd MMM dd yyyy";
            fechaInicio=DateTime.ParseExact(fechaInicio.Substring(0,15), format,provider).ToString();
            DateTime FechaInicio = Convert.ToDateTime(fechaInicio);
            fechaFin=DateTime.ParseExact(fechaFin.Substring(0,15), format,provider).ToString();
            DateTime FechaFin = Convert.ToDateTime(fechaFin);
            var result = (from p in _context.Set<Producto>()
                          join i in _context.Set<Inventario>()
                          on p.Referencia equals i.Referencia
                          join df in _context.Set<DFactura>()
                          on p.Referencia equals df.Referencia
                          join mf in _context.Set<MFactura>()
                          on df.MfacturaId equals mf.Id
                          where mf.TipoMovimiento == "Venta"
                          && mf.FechaPago >= FechaInicio && mf.FechaPago <= FechaFin
                          group df by new { df.Referencia, p.Descripcion } into newGroup1
                          select new 
                          {
                              Referencia = newGroup1.Key.Referencia,
                              Descripcion = newGroup1.Key.Descripcion,
                              Total = newGroup1.Sum(c => c.Cantidad)
                          }).OrderByDescending(i => i.Total).Take(10).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
    }
}