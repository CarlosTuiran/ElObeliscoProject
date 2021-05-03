using Aplicacion.Request;
using Aplicacion.Services.Eventos;
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
        public ComprarProductoService comprarProductoservice;

        private int Incremento = 1;

        public CrearFacturasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            this.crearMFacturaService = new CrearMFacturaService(_unitOfWork);
            this.crearDFacturaService = new CrearDFacturaService(_unitOfWork);
            this.comprarProductoservice=new ComprarProductoService(_unitOfWork);

        }

        public CrearFacturasResponse Ejecutar(CrearMFacturaRequest requestM)
        {
            
            var listMFacturas=_unitOfWork.MFacturaServiceRepository.GetAll();
            var lastMFactura = listMFacturas.TakeLast(1).ToArray();//ultima factura
            requestM.idMfactura = lastMFactura[0].idMfactura + 1;//otorga un nuevo id Mfactura
                                                                 //
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
                    ComprarProductoRequest requestComprar=new ComprarProductoRequest();
                    requestComprar.idMfactura = mfactura.Id;
                    requestComprar.TipoMovimiento=mfactura.TipoMovimiento;
                    var rta =comprarProductoservice.Ejecutar(requestComprar);
                    if(!rta.isOk())
                        return new CrearFacturasResponse { Message = rta.Message };
                }
                _unitOfWork.Commit(); //Todo Commit
                return new CrearFacturasResponse { Message = "Factura Creada Exitosamente" };
            }
            else
            {
                return new CrearFacturasResponse { Message = rtaMService.Message };
            }
  
            
        }
        public CrearFacturasResponse PreEjecutar(CrearMFacturaRequest requestM){
            var dfacturas=requestM.DFacturas;
            double subTotal=0;
            double iva = 0;
            foreach (var item in dfacturas)
            {
                Producto producto = _unitOfWork.ProductoServiceRepository.FindFirstOrDefault(t => t.Referencia == item.Referencia);
                iva += ((item.PrecioUnitario * item.Cantidad) * (producto.IVA/100));
                subTotal = subTotal+(item.PrecioUnitario*item.Cantidad);
            }
            return new   CrearFacturasResponse
            { Message = "Subtotal calculado", SubTotal = subTotal, IVA = iva };
        }
    }

}

