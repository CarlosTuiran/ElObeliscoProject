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
    public class UsuarioController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private CrearUsuarioService _service;
        private ActualizarUsuarioService _actualizarService;
        private UnitOfWork _unitOfWork;

        public UsuarioController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuario;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] int id)
        {
            Usuario usuario= await _context.Usuario.SingleOrDefaultAsync(t=>t.EmpleadoId==id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CrearUsuarioRequest usuario)
        {
            _service = new CrearUsuarioService(_unitOfWork);
            var rta = _service.Ejecutar(usuario);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { id=usuario.EmpleadoId}, usuario);                
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario([FromRoute] int id)
        {
            Usuario usuario = await _context.Usuario.SingleOrDefaultAsync(t => t.Id == id);
            if (usuario == null)
                return NotFound();
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario([FromRoute] int id, [FromBody] ActualizarUsuarioRequest usuario)
        {
            _actualizarService = new ActualizarUsuarioService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(usuario);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { id = usuario.EmpleadoId }, usuario);
            }
            return BadRequest(rta.Message);
        }
    }
}
