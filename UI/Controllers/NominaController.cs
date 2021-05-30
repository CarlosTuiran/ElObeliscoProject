using Aplicacion.Request;
using Aplicacion.Services.ActualizarServices;
using Aplicacion.Services.CrearServices;
using Aplicacion.Services.EliminarServices;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private EliminarNominaService _eliminarService;

        public NominaController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public Object GetNominas()
        {
            var result = (from n in _context.Set<Nomina>()
                          join e in _context.Set<Empleado>()
                          on n.IdEmpleado equals e.Id
                          select new
                          {
                              n.IdNomina,
                              IdEmpleado = e.Nombres + " " + e.Apellidos,
                              n.DiasTrabajados,
                              n.HoraExtraDiurna,
                              n.HoraExtraDiurnaFestivo,
                              n.HoraExtraNocturna,
                              n.HoraExtraNocturnaFestivo,
                              n.SalarioBase,
                              n.Comisiones
                          }).ToList();
            return result;
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

        [HttpDelete("{idN}/{id}")]
        public object DeleteNomina([FromRoute] string idN, int id)
        {
            _eliminarService = new EliminarNominaService(_unitOfWork);
            EliminarNominaRequest request = new EliminarNominaRequest();
            request.IdNomina = idN;
            request.IdEmpleado = id;
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                return Ok(rta);
            }
            return BadRequest(rta);
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
