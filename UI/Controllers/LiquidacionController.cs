using Aplicacion.Request;
using Aplicacion.Services.EliminarServices;
using Aplicacion.Services.Eventos;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
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
    public class LiquidacionController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private PagarEmpleadoService _service;
        private UnitOfWork _unitOfWork;
        private EliminarLiquidaciónService _eliminarService;

        public LiquidacionController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public Object GetLiquidaciones()
        {
            var result = (from l in _context.Set<Liquidacion>()
                          join e in _context.Set<Empleado>()
                          on l.IdEmpleado equals e.Id
                          select new
                          {
                              l.NominaId,
                              IdEmpleado = e.Id,
                              NombreEmpleado = e.Nombres,
                              l.Mes,
                              l.Anio,
                              l.SueldoOrdinario,
                              l.SubTransporte,
                              l.TotalDevengado,
                              l.Salud_Empleador,
                              l.Salud_Trabajador,
                              l.Pension_Trabajador,
                              l.Pension_Empleador,
                              l.Prima,
                              l.Cesantias,
                              l.Int_Cesantias,
                              l.Vacaciones,
                              l.Arl,
                              l.Caja_Comp,
                              l.ICBF,
                              l.SENA,
                              l.TotalDeducido,
                              l.TotalPagar
                          }).ToList();
            return result;
        }

        [HttpGet("{idNomina}/{idEmpleado}")]
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
                return CreatedAtAction("GetLiquidacion", nomina);
            }
            return BadRequest(rta);
        }

        [HttpDelete("{idN}/{id}")]
        public object DeleteLiquidacion([FromRoute] string idN, int id)
        {
            _eliminarService = new EliminarLiquidaciónService(_unitOfWork);
            EliminarlLiquidacionRequest request = new EliminarlLiquidacionRequest();
            request.NominaId = idN;
            request.IdEmpleado = id;
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                return Ok(rta);
            }
            return BadRequest(rta);
        }
    }
}
