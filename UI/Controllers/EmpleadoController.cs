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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Services.EliminarServices;
using System.Globalization;

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
        private EliminarEmpleadoService _eliminarService;
        CultureInfo provider = CultureInfo.InvariantCulture;

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

        [HttpPut("DeleteEmpleado/{id}")]
        public async Task<IActionResult> DeleteEmpleado([FromRoute] int id)
        {
            EliminarEmpleadoRequest empleado = new  EliminarEmpleadoRequest();
            empleado.IdEmpleado = id;
            _eliminarService = new EliminarEmpleadoService(_unitOfWork);
            var rta = _eliminarService.Ejecutar(empleado);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEmpleado", new { id = empleado.IdEmpleado }, empleado);
            }
            return BadRequest(rta.Message);
        }

        //? Top Empleados que mas venden
        [HttpGet("Top10Empleados")]
        public object Top10Empleados()
        {
            var result = (from e in _context.Set<Empleado>()
                          join mf in _context.Set<MFactura>()
                          on e.Id equals mf.EmpleadoId
                          join df in _context.Set<DFactura>()
                          on mf.Id equals df.MfacturaId
                          where mf.TipoMovimiento == "Venta"
                          group mf by new { e.Nombres, e.Apellidos, e.IdEmpleado } into newGroup1
                          select new
                          {
                              IdEmpleado = newGroup1.Key.IdEmpleado,
                              Nombre = newGroup1.Key.Nombres + " " + newGroup1.Key.Apellidos,
                              Total = newGroup1.Sum(c => c.Total)
                          }).OrderByDescending(i => i.Total).Take(10).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        //? Empleados que mas venden intervalo
        [HttpGet("Top10EmpleadosInterval/{fechaInicio}/{fechaFin}")]
        public object Top10EmpleadosInterval([FromRoute] string fechaInicio,[FromRoute] string fechaFin )
        {
            string format="ddd MMM dd yyyy";
            fechaInicio=DateTime.ParseExact(fechaInicio.Substring(0,15), format,provider).ToString();
            DateTime FechaInicio = Convert.ToDateTime(fechaInicio);
            fechaFin=DateTime.ParseExact(fechaFin.Substring(0,15), format,provider).ToString();
            DateTime FechaFin = Convert.ToDateTime(fechaFin);
            var result = (from e in _context.Set<Empleado>()
                          join mf in _context.Set<MFactura>()
                          on e.Id equals mf.EmpleadoId
                          join df in _context.Set<DFactura>()
                          on mf.Id equals df.MfacturaId
                          where mf.TipoMovimiento == "Venta"
                          && mf.FechaPago >= FechaInicio && mf.FechaPago <= FechaFin
                          group mf by new { e.Nombres, e.Apellidos, e.IdEmpleado } into newGroup1
                          select new
                          {
                              IdEmpleado = newGroup1.Key.IdEmpleado,
                              Nombre = newGroup1.Key.Nombres + " " + newGroup1.Key.Apellidos,
                              Total = newGroup1.Sum(c => c.Total)
                          }).OrderByDescending(i => i.Total).Take(10).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
    }
}
