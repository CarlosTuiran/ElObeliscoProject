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
    public class TipoMovimientoController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private UnitOfWork _unitOfWork;
        

        public TipoMovimientoController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<TipoMovimiento> GetTipoMovimientos()
        {
            return _context.TipoMovimiento;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoMovimiento([FromRoute] int id)
        {
            TipoMovimiento TipoMovimiento = await _context.TipoMovimiento.SingleOrDefaultAsync(t => t.idMovimiento == id);
            if (TipoMovimiento == null)
                return NotFound();
            return Ok(TipoMovimiento);
        }

        
    }
}
