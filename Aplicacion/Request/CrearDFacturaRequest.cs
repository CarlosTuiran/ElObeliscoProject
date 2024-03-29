﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearDFacturaRequest
    {
        public int Id { get; set; }
        public int MfacturaId { get; set; }
        public string Referencia { get; set; }
        public int PromocionId { get; set; }
        public double IVA { get; set; }
        public string Bodega { get; set; }
        public string FormatoProducto { get; set; }
        public double Cantidad { get; set; }
        public double CantidadDigitada { get; set; }
        public double PrecioUnitario { get; set; }
        public DateTime FechaFactura { get => DateTime.Now.Date; }
        public double PrecioTotal { get; set; }
    }
    public class CrearDFacturaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Detalles de Factura Creado Exitosamente");
        }
    }
}
