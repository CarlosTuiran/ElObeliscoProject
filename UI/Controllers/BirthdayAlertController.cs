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
    public class BirthdayAlertController : ControllerBase
    {
        private readonly ObeliscoContext _context;
        private UnitOfWork _unitOfWork;
        
        public BirthdayAlertController(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public object GetTercerosCumple()
        {
            var result = (from c in _context.Set<Terceros>()
                          where c.FechaCumple.Day == DateTime.Now.Day && c.FechaCumple.Month == DateTime.Now.Month
                          select new
                          {
                             Nit=c.Nit,
                             Nombre=c.Nombre,
                             Apellido=c.Apellido
                             
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

    }
}
