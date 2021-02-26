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
using Aplicacion.Services.EliminarServices;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalLiquidacionController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private CrearTotalLiquidacionService _service;
        private UnitOfWork _unitOfWork;
        private EliminarTotalLiquidacionService _eliminarService;
        public TotalLiquidacionController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<TotalLiquidacion> GetTotalLiquidaciones()
        {
            return _context.TotalLiquidacion;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTotalLiquidacion([FromRoute] string idN, int mes, int anio)
        {
            TotalLiquidacion totalLiquidacion = await _context.TotalLiquidacion.SingleOrDefaultAsync(t => t.NominaId == idN && t.Mes == mes && t.Anio == anio);
            if (totalLiquidacion == null)
                return NotFound();
            return Ok(totalLiquidacion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTotalLiquidacion()
        {
            _service = new CrearTotalLiquidacionService(_unitOfWork);
            var rta =  _service.Ejecutar();
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(rta.Message);

        }

        [HttpDelete("{id}")]
        public object DeleteUsuario([FromRoute] string id)
        {
            _eliminarService = new EliminarTotalLiquidacionService(_unitOfWork);
            EliminarTotalLiquidacionRequest request = new EliminarTotalLiquidacionRequest();
            request.NominaId = id;
            var rta = _eliminarService.Ejecutar(request);
            return Ok(rta);
        }
    }
}
