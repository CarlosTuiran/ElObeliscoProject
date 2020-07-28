﻿using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Models.Entities
{
    public class Producto : Entity<int>
    {
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string FormatoVenta { get; set; }
        public string Marca { get; set; }
        public string Fabrica { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public double IVA { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Producto()
        {

        }        
        public Producto(string referencia, string descripcion, string formatoventa, string marca ,string fabrica,
            double costo, double precioventa, double iva)
        {
            this.Referencia = referencia;
            this.Descripcion = descripcion;
            this.FormatoVenta = formatoventa;
            this.Marca = marca;
            this.Fabrica = fabrica;
            this.Costo = costo;
            this.PrecioVenta = precioventa;
            this.IVA = iva;
            this.FechaRegistro = DateTime.Now;
        }

        public IReadOnlyList<string> CanCrear(Producto producto)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(producto.Referencia))
                errors.Add("Campo Referencia vacio");
            if (string.IsNullOrEmpty(producto.FormatoVenta))
                errors.Add("Campo FormatoVenta vacio");
            if (producto.Costo < 0)
                errors.Add("Campo Costo negativo");
            if (producto.PrecioVenta < 0)
                errors.Add("Campo PrecioVenta negativo");
            if (producto.FechaRegistro == null)
                errors.Add("Campo FechaRegistro vacio");
            return errors;
        }
    }
 }
