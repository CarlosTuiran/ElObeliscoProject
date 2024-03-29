﻿using Domain.Models.Base;
using Domain.Models.Entities.Operacionales;
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
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string IdProveedor { get; set; }
        public string? Fabrica { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int CantidadMinima { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public int CuentaIngreso { get; set; }
        public int CuentaDevolucion { get; set; }
           
        
        public List<ProductoDFactura> ProductoDFacturas { get; set; }

        public Producto()
        {

        }

        public Producto(string referencia, string descripcion, string formatoVenta, int idMarca, 
            int idCategoria, string idProveedor, string fabrica, double costo, double precioVenta, 
            int cantidadMinima, DateTime fechaRegistro, string estado, int cuentaIngreso,
            int cuentaDevolucion)
        {
            Referencia = referencia;
            Descripcion = descripcion;
            FormatoVenta = formatoVenta;
            IdMarca = idMarca;
            IdCategoria = idCategoria;
            IdProveedor = idProveedor;
            Fabrica = fabrica;
            Costo = costo;
            PrecioVenta = precioVenta;
            CantidadMinima = cantidadMinima;
            FechaRegistro = fechaRegistro;
            Estado = estado;
            CuentaIngreso=cuentaIngreso;
            CuentaDevolucion=cuentaDevolucion;
        }

        public IReadOnlyList<string> CanCrear(Producto producto)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(producto.Referencia))
                errors.Add("Campo Referencia vacio");
            if (string.IsNullOrEmpty(producto.Descripcion))
                errors.Add("Campo Descripcion vacio");
            if (string.IsNullOrEmpty(producto.FormatoVenta))
                errors.Add("Campo FormatoVenta vacio");
            if (producto.Costo <= 0)
                errors.Add("Campo Costo negativo o vacio");
            if (producto.IdMarca <= 0)
                errors.Add("Campo marca negativo o vacio");
            if (producto.IdCategoria <= 0)
                errors.Add("Campo categoría negativo o vacio");
            if (string.IsNullOrEmpty(producto.IdProveedor))
                errors.Add("Campo proveedor vacio");
            if (producto.PrecioVenta <= 0)
                errors.Add("Campo PrecioVenta negativo");
            if (producto.Costo <= 0)
                errors.Add("Campo costo negativo o vacio");
            if (producto.CantidadMinima <= 0)
                errors.Add("Campo cantidad minima negativo o vacio");
            if (string.IsNullOrEmpty(producto.FechaRegistro.ToString()))
                errors.Add("Campo FechaRegistro vacio");
            if (string.IsNullOrEmpty(producto.Estado))
                errors.Add("Campo Estado vacio");
            if(producto.CuentaIngreso<= 0)
                errors.Add("Campo CuentaIngreso vacio");
            if(producto.CuentaDevolucion<= 0)
                errors.Add("Campo CuentaDevolucion vacio");
            return errors;
        }
    }
 }
