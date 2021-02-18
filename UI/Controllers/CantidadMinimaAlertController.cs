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
    public class CantidadMinimaAlertController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private UnitOfWork _unitOfWork;
        
        public CantidadMinimaAlertController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public object GetProductosMinimos()
        {
            var result = (from p in _context.Set<Producto>()
                          join i in _context.Set<Inventario>()
                          on p.Referencia equals i.Referencia
                          where i.Cantidad < p.CantidadMinima
                          select new
                          {
                             Referencia = p.Referencia,
                             Cantidad = i.Cantidad,
                             CantidadMinima = p.CantidadMinima,
                             
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

    }
}
