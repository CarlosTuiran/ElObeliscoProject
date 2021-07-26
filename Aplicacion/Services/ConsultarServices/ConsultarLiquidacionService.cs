﻿using Aplicacion.Request.Salidas;
using Domain.Models.Entities;
using Infra.Datos;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Services.ConsultarServices
{
    public class ConsultarLiquidacionService
    {
        readonly ObeliscoContext _context;
        readonly ConsultarLiquidacionResponse _response;

        public ConsultarLiquidacionService(ObeliscoContext context)
        {
            _context = context;
            _response = new ConsultarLiquidacionResponse();
        }

        public ConsultarLiquidacionResponse Ejecutar(int IdEmpleado, string idNomina)
        {
            var liquidacion = (from liq in _context.Set<Liquidacion>()
                               join nom in _context.Set<Nomina>()
                               on liq.NominaId equals nom.IdNomina
                               join emp in _context.Set<Empleado>()
                               on nom.IdEmpleado equals emp.Id
                               where nom.IdNomina == idNomina
                               select new
                               {
                                   liq.NominaId,
                                   Id = emp.Id,
                                   emp.IdEmpleado,
                                   NombreMov = "Liquidacion",
                                   Serial = nom.IdNomina + "-" + emp.IdEmpleado,
                                   Nombre = emp.Nombres+" "+emp.Apellidos,
                                   nom.DiasTrabajados,
                                   emp.Cargo,
                                   emp.Correo,
                                   emp.Celular,
                                   emp.FechaIngreso,
                                   emp.Direccion,
                                   liq.Mes,
                                   liq.Anio,
                                   liq.SueldoOrdinario,
                                   liq.SubTransporte,
                                   nom.Comisiones,
                                   liq.Salud_Trabajador,
                                   liq.Pension_Trabajador,
                                   liq.TotalPagar,
                               }).FirstOrDefault(t => t.Id == IdEmpleado);
            if (liquidacion != null)
            {
                _response.NominaId = liquidacion.NominaId;
                _response.IdEmpleado = liquidacion.IdEmpleado;
                _response.NombreMov = liquidacion.NombreMov;
                _response.Serial = liquidacion.Serial;
                _response.Cargo = liquidacion.Cargo;
                _response.DiasTrabajados = liquidacion.DiasTrabajados;
                _response.Correo = liquidacion.Correo;
                _response.Celular = liquidacion.Celular;
                _response.FechaIngreso = liquidacion.FechaIngreso;
                _response.Direccion = liquidacion.Direccion;
                _response.Mes = liquidacion.Mes;
                _response.Anio = liquidacion.Anio;
                _response.SueldoOrdinario = liquidacion.SueldoOrdinario.ToString("C2");
                _response.SubTransporte = liquidacion.SubTransporte.ToString("C2");
                _response.Comisiones = liquidacion.Comisiones.ToString("C2");
                _response.Salud_Trabajador = liquidacion.Salud_Trabajador.ToString("C2");
                _response.Pension_Trabajador = liquidacion.Pension_Trabajador.ToString("C2");
                _response.Nombre = liquidacion.Nombre;
                _response.TotalDevengos = (liquidacion.SueldoOrdinario 
                    + liquidacion.SubTransporte 
                    + liquidacion.Comisiones).ToString("C2");
                _response.TotalDeducciones = (liquidacion.Salud_Trabajador
                    + liquidacion.Pension_Trabajador).ToString("C2");
                _response.TotalPagar = liquidacion.TotalPagar.ToString("C2");
            }
            return _response;
        }
    }
}