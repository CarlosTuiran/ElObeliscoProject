using System;
using System.Collections.Generic;

namespace Aplicacion.Request
{
    public class CrearProductoRequest
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
        public string Estado { get => "Activo"; }
        public int CuentaIngreso { get; set; }
        public int CuentaDevolucion { get; set; }
        public List<int> IdImpuestos { get; set; }

    }
    public class CrearProductoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Producto Creado Exitosamente");
        }
    }


}
