﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearFacturasResponse
    {
        public string Message { get; set; }
        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Factura Creada Exitosamente");
        }
        public bool isOkSubTotal()
        {
            return this.Message.Equals("Subtotal calculado");
        }
    }
}
