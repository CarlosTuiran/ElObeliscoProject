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
    public class FacturaController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private CrearFacturasService _service;
        private UnitOfWork _unitOfWork;

        public FacturaController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }
        [HttpGet]
        public IEnumerable<MFactura> GetMFacturas()
        {
            return _context.MFactura;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMFactura([FromRoute] int id)
        {
            MFactura factura = await _context.MFactura.SingleOrDefaultAsync(t => t.Id == id);
            if (factura== null)
                return NotFound();
            return Ok(factura);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFacturas([FromBody] CrearMFacturaRequest requestM, [FromBody] List<CrearDFacturaRequest> requestD)
        {
            _service = new CrearFacturasService(_unitOfWork);
            var rta = _service.Ejecutar(requestM, requestD);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { id = requestM.idMfactura }, requestM);
            }
            return BadRequest(rta.Message);
        }
    }
}
