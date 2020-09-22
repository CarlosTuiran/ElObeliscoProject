using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Services.CrearServices;
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
    public class UsuarioController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private CrearUsuarioService _service;
        private UnitOfWork _unitOfWork;

        public UsuarioController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> getUsuarios()
        {
            var data = await _context.Usuario.ToListAsync();
            return Ok(data);
        }
        /*
        [HttpPost]
        public ActionResult PostConvenio([FromBody] CrearEmpresaRequest empresa)
        {
            _service = new CrearEmpresaService(_unitOfWork);
            var rta = _service.Ejecutar(empresa);
            if (rta.isOk())
                return Ok(rta.Message);
            return BadRequest(rta.Message);
        }*/
    }
}
