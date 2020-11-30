using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Request;
using Aplicacion.Services.CrearServices;
using Aplicacion.Services.ActualizarServices;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.InterfazWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominaController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private CrearNominaService _service;
        private UnitOfWork _unitOfWork;
        private ActualizarNominaService _actualizarService;

        public NominaController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Nomina> GetNominas()
        {
            return _context.Nomina;
        }

        [HttpGet("{idN}/{id}")]
        public async Task<IActionResult> GetNomina([FromRoute] string idN, int id)
        {
            Nomina nomina = await _context.Nomina.SingleOrDefaultAsync(t => t.IdEmpleado == id && t.IdNomina == idN);
            if (nomina == null)
                return NotFound();
            return Ok(nomina);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNomina([FromBody] CrearNominaRequest nomina)
        {
            _service = new CrearNominaService(_unitOfWork);
            var rta = _service.Ejecutar(nomina);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetNomina", new { idN = nomina.IdNomina, id = nomina.IdEmpleado }, nomina);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomina([FromRoute] string idN, int id)
        {
            Nomina nomina = await _context.Nomina.SingleOrDefaultAsync(t => t.IdEmpleado == id && t.IdNomina == idN);
            if (nomina == null)
                return NotFound();
            _context.Nomina.Remove(nomina);
            await _context.SaveChangesAsync();
            return Ok(nomina);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomina([FromRoute] int id, [FromBody] ActualizarNominaRequest nomina)
        {
            _actualizarService = new ActualizarNominaService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(nomina);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetNomina", new { id = nomina.IdEmpleado }, nomina);
            }
            return BadRequest(rta.Message);
        }
    }
}
