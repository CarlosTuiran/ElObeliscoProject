using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarProductoRequest
    {
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string FormatoVenta { get; set; }
        public string Marca { get; set; }
        public string Fabrica { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public double IVA { get; set; }

    }
    public class ActualizarProductoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Producto Actualizado Exitosamente");
        }
    }
}