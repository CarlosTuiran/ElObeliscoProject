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
    public class EmpleadoController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private CrearEmpleadoService _service;
        private UnitOfWork _unitOfWork;
        private ActualizarEmpleadoService _actualizarService;

        public EmpleadoController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Empleado> GetEmpleados()
        {
            return _context.Empleado;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleado([FromRoute] int id)
        {
            Empleado empleado = await _context.Empleado.SingleOrDefaultAsync(t => t.IdEmpleado == id);
            if (empleado == null)
                return NotFound();
            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpleado([FromBody] CrearEmpleadoRequest empleado)
        {
            _service = new CrearEmpleadoService(_unitOfWork);
            var rta = _service.Ejecutar(empleado);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEmpleado", new { id = empleado.IdEmpleado }, empleado);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado([FromRoute] int id)
        {
            Empleado empleado = await _context.Empleado.SingleOrDefaultAsync(t => t.IdEmpleado == id);
            if (empleado == null)
                return NotFound();
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return Ok(empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado([FromRoute] int id, [FromBody] ActualizarEmpleadoRequest empleado)
        {
            _actualizarService = new ActualizarEmpleadoService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(empleado);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEmpleado", new { id = empleado.IdEmpleado }, empleado);
            }
            return BadRequest(rta.Message);
        }
    }
}
