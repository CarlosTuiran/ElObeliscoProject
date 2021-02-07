using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.CrearServices
{
    public class CrearFacturasService
    {
        readonly IUnitOfWork _unitOfWork;
        public CrearMFacturaService crearMFacturaService;
        public CrearDFacturaService crearDFacturaService;
        private int Incremento = 1;

        public CrearFacturasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            this.crearMFacturaService = new CrearMFacturaService(unitOfWork);
            this.crearDFacturaService = new CrearDFacturaService(unitOfWork);
        }

        public CrearFacturasResponse Ejecutar(CrearMFacturaRequest requestM)
        {
            Console.WriteLine(requestM.FechaPago);
            var listMFacturas=_unitOfWork.MFacturaServiceRepository.GetAll();
            var lastMFactura = listMFacturas.TakeLast(1).ToArray();//ultima factura
            requestM.idMfactura = lastMFactura[0].idMfactura + 1;//otorga un nuevo id Mfactura
            if(requestM.EstadoFactura == "Pendiente"){
                requestM.FechaPago = null;
            }
            
            var rtaMService = crearMFacturaService.Ejecutar(requestM);
            
            if (rtaMService.isOk())
            {
                var requestD=requestM.DFacturas;
                foreach (var item in requestD)
                {
                    
                    var mfactura =_unitOfWork.MFacturaServiceRepository.FindFirstOrDefault(t=>t.idMfactura == requestM.idMfactura); //Relaciona cada d factura con la m factura
                    item.MfacturaId = mfactura.Id;
                    item.idDFactura = Convert.ToInt32(item.MfacturaId.ToString() + "0" + Incremento);
                    Incremento += 1;
                    var producto = _unitOfWork.ProductoServiceRepository.FindFirstOrDefault(t => t.Referencia == item.Referencia);
                    item.PrecioUnitario = producto.PrecioVenta;
                    var rtaDService=crearDFacturaService.Ejecutar(item);
                    if(!rtaDService.isOk())
                        return new CrearFacturasResponse { Message = rtaDService.Message };
                }
                _unitOfWork.Commit();
                return new CrearFacturasResponse { Message = "Factura Creada Exitosamente" };
            }
            else
            {
                return new CrearFacturasResponse { Message = rtaMService.Message };
            }

            
        }
    }
}
