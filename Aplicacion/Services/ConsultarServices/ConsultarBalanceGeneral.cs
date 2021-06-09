using Aplicacion.Request.Salidas;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using Infra.Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Services.ConsultarServices
{
    public class ConsultarBalanceGeneralService
    {
        readonly ObeliscoContext _context;
        readonly ConsultarBalanceGeneralResponse response;
        public ConsultarBalanceGeneralService(ObeliscoContext context)
        {
            _context = context;
            response = new ConsultarBalanceGeneralResponse
            {                
                ActivosCorrientes = new List<CuentasBalances>(),
                PasivosCorrientes = new List<CuentasBalances>() ,
                Patrimonio = new List<CuentasBalances> ()
            };
        }
        public ConsultarBalanceGeneralResponse Ejecutar()
        {
            // var activosCorrientes = _context.LibroContable.Where(t => t.Codigo.ToString().StartsWith("1"))
            // .GroupBy(l => l.Codigo)
            // .Select(cl => new CuentasBalances
            // {
            //     Concepto = _context.Cuenta.Where(x => x.Codigo == cl.FirstOrDefault().Codigo).FirstOrDefault().Nombre,
            //     ValorTotal = (cl.Sum(c => c.Debe) - cl.Sum(c => c.Haber)).Value.ToString("C2")
            // });
            var activosCorrientes1 = _context.LibroContable.Where(t => t.Codigo.ToString().StartsWith("1")).ToList();
            var activosCorrientes2=activosCorrientes1.GroupBy(l => l.Codigo).Select(cl => new CuentasBalances
             {
                 Concepto = _context.Cuenta.Where(x => x.Codigo == cl.FirstOrDefault().Codigo).FirstOrDefault().Nombre,
                 ValorTotal = (cl.Sum(c => c.Debe) - cl.Sum(c => c.Haber)).Value.ToString("C2"),
                 ValorNumerico= cl.Sum(c => c.Debe) - cl.Sum(c => c.Haber)
            }).ToList();
            var pasivosCorrientes1 = _context.LibroContable.Where(t => t.Codigo.ToString().StartsWith("2")).ToList();
            var pasivosCorrientes2 = pasivosCorrientes1.GroupBy(l => l.Codigo).Select(cl => new CuentasBalances
            {
                Concepto = _context.Cuenta.Where(x => x.Codigo == cl.FirstOrDefault().Codigo).FirstOrDefault().Nombre,
                ValorTotal = (cl.Sum(c => c.Debe) - cl.Sum(c => c.Haber)).Value.ToString("C2"),
                 ValorNumerico= cl.Sum(c => c.Debe) - cl.Sum(c => c.Haber)
            }).ToList();
            var patrimonio1 = _context.LibroContable.Where(t => t.Codigo.ToString().StartsWith("3")).ToList();
            var patrimonio2 = patrimonio1.GroupBy(l => l.Codigo).Select(cl => new CuentasBalances
            {
                Concepto = _context.Cuenta.Where(x => x.Codigo == cl.FirstOrDefault().Codigo).FirstOrDefault().Nombre,
                ValorTotal = (cl.Sum(c => c.Debe) - cl.Sum(c => c.Haber)).Value.ToString("C2"),
                ValorNumerico = cl.Sum(c => c.Debe) - cl.Sum(c => c.Haber)
            }).ToList();
            response.ActivosCorrientes = activosCorrientes2;
            response.PasivosCorrientes = pasivosCorrientes2;
            response.PasivosCorrientes = patrimonio2;
            response.ActivoCorrienteTotal = (activosCorrientes2.Sum(x => x.ValorNumerico)).Value.ToString("C2");
            response.PasivoCorrienteTotal = (pasivosCorrientes2.Sum(x => x.ValorNumerico)).Value.ToString("C2");
            response.PatrimonioTotal = (patrimonio2.Sum(x => x.ValorNumerico)).Value.ToString("C2");

            response.NombreMov = "Balance General";
            response.Serial = "BG-"+ DateTime.Now.ToString("dd-MM-yyyy");
            return response;
        }
    }
}