using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Request;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.InterfazWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private UnitOfWork _unitOfWork;

        public InventarioController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public Object GetInventarios()
        {
            var result = (from i in _context.Set<Inventario>()
                          join p in _context.Set<Producto>()
                          on i.Referencia equals p.Referencia
                          select new
                          {
                              Referencia = i.Referencia,
                              Descripcion = p.Descripcion,
                              Cantidad = i.Cantidad,
                              PrecioVenta = p.PrecioVenta
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
    }
}
