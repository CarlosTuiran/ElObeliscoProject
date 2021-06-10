using Aplicacion.Request;
using Aplicacion.Services.Eventos;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.InterfazWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroContableController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly PartidaDobleService _partidaDobleService;

        public LibroContableController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _partidaDobleService = new PartidaDobleService(_unitOfWork);
        }

        [HttpGet]
        public object LibroContable()
        {
            return _context.LibroContable;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibroContable([FromBody] LibroContableRequest request)
        {
            var rta = _partidaDobleService.RegistroLibroContable(request);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetLibroContable", request);
            }
            return BadRequest(rta.Message);
        }

    }
}
