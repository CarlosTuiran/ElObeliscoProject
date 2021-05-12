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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        private readonly ObeliscoContext _context;            
        private readonly UnitOfWork _unitOfWork;
        private readonly CrearCuentaService _crearService;
        private readonly ActualizarCuentaService _actualizarService;
        private readonly EliminarCuentaService _eliminarService;

        public CuentaController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearCuentaService(_unitOfWork);
            _actualizarService = new ActualizarCuentaService(_unitOfWork);
            _eliminarService = new EliminarCuentaService(_unitOfWork);
        }
        [HttpGet]
        public IEnumerable<Cuenta> GetCuentas()
        {
            return _context.Cuenta;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuenta([FromRoute] int id)
        {
            Cuenta cuenta = await _context.Cuenta.SingleOrDefaultAsync(t => t.Id == id);
            if (cuenta == null)
                return NotFound();
            return Ok(cuenta);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCuenta([FromBody] CrearCuentaRequest cuentaRequest)
        {
            var rta = _crearService.Ejecutar(cuentaRequest);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCuenta", new { Id = cuentaRequest.Codigo }, cuentaRequest);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuenta([FromRoute] int id, [FromBody] ActualizarCuentaRequest cuentaRequest)
        {
            var rta = _actualizarService.Ejecutar(cuentaRequest);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCuenta", new { id = cuentaRequest.Id }, cuentaRequest);
            }
            return BadRequest(rta.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta([FromRoute] int id)
        {
            var rta = _eliminarService.Ejecutar(id);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCuenta", new { Id = id });
            }
            return BadRequest(rta.Message);
        }
    }
}
