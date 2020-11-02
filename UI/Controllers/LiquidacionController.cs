using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Request;
using Aplicacion.Services.CrearServices;
using Aplicacion.Services.Eventos;
using Aplicacion.Services.ActualizarServices;
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
    public class LiquidacionController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private PagarEmpleadoService _service;
        private UnitOfWork _unitOfWork;

        public LiquidacionController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Liquidacion> GetLiquidaciones()
        {
            return _context.Liquidacion;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLiquidacion([FromRoute] string idNomina, int idEmpleado)
        {
            Liquidacion liquidacion = await _context.Liquidacion.SingleOrDefaultAsync(t => t.NominaId == idNomina && t.IdEmpleado == idEmpleado);
            if (liquidacion == null)
                return NotFound();
            return Ok(liquidacion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLiquidacion([FromBody] PagarEmpleadoRequest nomina)
        {
            _service = new PagarEmpleadoService(_unitOfWork);
            var rta = _service.Ejecutar(nomina);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetLiquidacion", new { idN = nomina.IdNomina, idL = nomina.IdEmpleado }, nomina);
            }
            return BadRequest(rta.Message);
        }
    }
}
