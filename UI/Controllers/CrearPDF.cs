using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearPDF : ControllerBase
    {
        private readonly ObeliscoContext _context;

        public CrearPDF(ObeliscoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var resultado = _context.Usuario.FirstOrDefault(u => u.Id == 1).Nombre;
            return new ViewAsPdf("Index"){
                Model=resultado
            };
           
        }
        
    }
}
