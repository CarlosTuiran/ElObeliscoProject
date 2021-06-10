using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;

namespace Aplicacion.Services.Eventos
{
    public class PartidaDobleService
    {
        readonly IUnitOfWork _unitOfWork;
        public PartidaDobleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Comprar(CrearMFacturaRequest mFactura)
        {
            try
            {
                var cuentaImpuesto = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == 2408);
                foreach (var item in mFactura.DFacturas)
                {
                    var producto = _unitOfWork.ProductoServiceRepository.FindFirstOrDefault(t => t.Referencia == item.Referencia);
                    var cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Id == producto.CuentaIngreso);
                    var libroContable = new LibroContable(cuenta.Codigo, "Compra Producto " + producto.Descripcion, mFactura.idMfactura.ToString(), "Factura", mFactura.FechaFactura);
                    //Debe o Haber
                    if (cuenta.Naturaleza == "Débito")
                    {
                        libroContable.Debe = item.PrecioTotal - item.IVA;
                    }
                    else
                    {
                        libroContable.Haber = item.PrecioTotal - item.IVA;
                    }
                    //impuestos y deveg
                    var libroContableImp = new LibroContable(cuentaImpuesto.Codigo, "Impuestos Producto " + producto.Descripcion, mFactura.idMfactura.ToString(), "Factura", mFactura.FechaFactura);
                    libroContableImp.Debe = item.IVA;
                    Cuenta cuentaHaber;
                    switch (mFactura.TipoMovimientoId)
                    {
                        case 1:
                            //"Efectivo"
                            cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo ==
                              _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Efectivo").ValorNumerico);
                            break;
                        case 2:
                            //"Credito"
                            cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo ==
                              _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Credito").ValorNumerico);
                            break;
                        case 3:
                            //"Cheque"
                            cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo ==
                              _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Cheque").ValorNumerico);
                            break;
                        case 4:
                            //"Pago Virtual"
                            cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo ==
                              _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Pago Virtual").ValorNumerico);
                            break;
                        case 5:
                            //Devolucion
                            cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Id == producto.CuentaDevolucion);
                            break;
                        default:
                            cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == 1105);
                            break;
                    }
                    var libroContableHaber = new LibroContable(cuentaHaber.Codigo, "Compra Producto " + producto.Descripcion, mFactura.idMfactura.ToString(), "Factura", mFactura.FechaFactura);
                    libroContableHaber.Haber = item.PrecioTotal;

                    //?que estoy haciendo?=
                    _unitOfWork.LibroContableServiceRepository.Add(libroContable);
                    _unitOfWork.LibroContableServiceRepository.Add(libroContableImp);
                    _unitOfWork.LibroContableServiceRepository.Add(libroContableHaber);

                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }

        public CrearLibroContableResponse RegistroLibroContable(LibroContableRequest libroContableRequest)
        {
            libroContableRequest.Codigo = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Id == libroContableRequest.Codigo).Codigo;
            var cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == libroContableRequest.Codigo);
            if (cuenta == null)
            {
                return new CrearLibroContableResponse($"No existe la cuenta");
            }
            var libroContable = new LibroContable(libroContableRequest.Codigo, "Registro libro contable " + libroContableRequest.Descripcion, libroContableRequest.OrigenId.ToString(), "Libro Contable", libroContableRequest.Fecha);
            //Debe o Haber
            if (cuenta.Naturaleza == "Débito")
            {
                libroContable.Debe = libroContableRequest.Valor;
            }
            else
            {
                libroContable.Haber = libroContableRequest.Valor;
            }
            Cuenta cuentaHaber;
            switch (libroContableRequest.TipoMovimientoId)
            {
                case 1:
                    //"Efectivo"
                    var efectivo = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Efectivo").ValorNumerico;
                    cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == efectivo);
                    break;
                case 2:
                    //"Credito"
                    var credito = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Credito").ValorNumerico;
                    cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == credito);
                    break;
                case 3:
                    //"Cheque"
                    var cheque = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Cheque").ValorNumerico;
                    cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == cheque);
                    break;
                case 4:
                    //"Pago Virtual"
                    var pagoVirtual = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Pago Virtual").ValorNumerico;
                    cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == pagoVirtual);
                    break;
                default:
                    cuentaHaber = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == 1105);
                    break;
            }
            var libroContableHaber = new LibroContable(cuentaHaber.Codigo, "Registro libro contable " + libroContableRequest.Descripcion, libroContableRequest.OrigenId.ToString(), "Libro Contable", libroContableRequest.Fecha)
            {
                Haber = libroContableRequest.Valor
            };

            _unitOfWork.LibroContableServiceRepository.Add(libroContable);
            _unitOfWork.LibroContableServiceRepository.Add(libroContableHaber);
            _unitOfWork.Commit();
            return new CrearLibroContableResponse($"Libro Contable Creado Exitosamente");
        }
        public int Vender(CrearMFacturaRequest mFactura)
        {
            try
            {
                var cuentaImpuesto = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == 2408);
                foreach (var item in mFactura.DFacturas)
                {
                    var producto = _unitOfWork.ProductoServiceRepository.FindFirstOrDefault(t => t.Referencia == item.Referencia);
                    //? 4135 Comercio al por mayor
                    var cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == 4135);
                    var libroContable = new LibroContable(cuenta.Codigo, "Venta Producto " + producto.Descripcion, mFactura.idMfactura.ToString(), "Factura", mFactura.FechaFactura);
                    //Debe o Haber
                    if (cuenta.Naturaleza == "Débito")
                    {
                        libroContable.Debe = item.PrecioTotal - item.IVA;
                    }
                    else
                    {
                        libroContable.Haber = item.PrecioTotal - item.IVA;
                    }
                    //impuestos y deveg
                    var libroContableImp = new LibroContable(cuentaImpuesto.Codigo, "Impuestos Producto " + producto.Descripcion, mFactura.idMfactura.ToString(), "Factura", mFactura.FechaFactura);
                    libroContableImp.Haber = item.IVA;
                    Cuenta cuentaDebe;
                    switch (mFactura.TipoMovimientoId)
                    {
                        case 1:
                            //"Efectivo"
                            cuentaDebe = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo ==
                               _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Efectivo").ValorNumerico);
                            break;
                        case 2:
                            //"Credito"
                            cuentaDebe = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo ==
                              _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Credito").ValorNumerico);
                            break;
                        case 3:
                            //"Cheque"
                            cuentaDebe = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo ==
                              _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Cheque").ValorNumerico);
                            break;
                        case 4:
                            //"Pago Virtual"
                            cuentaDebe = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo ==
                              _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "Pago Virtual").ValorNumerico);
                            break;
                        case 5:
                            //Devolucion
                            cuentaDebe = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Id == producto.CuentaDevolucion);
                            break;
                        default:
                            cuentaDebe = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == 1105);
                            break;
                    }
                    var libroContableDebe = new LibroContable(cuentaDebe.Codigo, "Compra Producto " + producto.Descripcion, mFactura.idMfactura.ToString(), "Factura", mFactura.FechaFactura);
                    libroContableDebe.Debe = item.PrecioTotal;

                    //?que estoy haciendo?=
                    _unitOfWork.LibroContableServiceRepository.Add(libroContable);
                    _unitOfWork.LibroContableServiceRepository.Add(libroContableImp);
                    _unitOfWork.LibroContableServiceRepository.Add(libroContableDebe);

                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }
        public int LiquidarTotalLiquidacion(TotalLiquidacion TotalLiquidacion)
        {
            try
            {
                var retencionesParam = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "retencion aporte nomina");//2370 
                var acreedoresParam = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "acreedores varios"); //2380
                var provisionParam = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "provision"); //2610
                var salariosParam = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "salarios por pagar");// 2505
                var gastopersonalParam = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == "gasto personal"); //5105
                var retencionesCuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == retencionesParam.ValorNumerico);
                var acreedoresCuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == acreedoresParam.ValorNumerico);
                var provisionCuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == provisionParam.ValorNumerico);
                var salariosCuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == salariosParam.ValorNumerico);
                var gastopersonalCuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == gastopersonalParam.ValorNumerico);
                var nominaActual = DateTime.Now.Month + " - " + DateTime.Now.Year;
                //var TotalLiquidacion = _unitOfWork.TotalLiquidacionServiceRepository.FindFirstOrDefault(t => t.NominaId == nominaActual);
                var libroContable1 = new LibroContable(retencionesCuenta.Codigo, "Retencion aporte nomina " + nominaActual, nominaActual, "Nomina", DateTime.Now);
                var libroContable2 = new LibroContable(acreedoresCuenta.Codigo, "Acreedores varios " + nominaActual, nominaActual, "Nomina", DateTime.Now);
                var libroContable3 = new LibroContable(provisionCuenta.Codigo, "Provision " + nominaActual, nominaActual, "Nomina", DateTime.Now);
                var libroContable4 = new LibroContable(salariosCuenta.Codigo, "Salarios por pagar " + nominaActual, nominaActual, "Nomina", DateTime.Now);
                var libroContable5 = new LibroContable(gastopersonalCuenta.Codigo, "Gasto personal " + nominaActual, nominaActual, "Nomina", DateTime.Now);
                libroContable1.Haber = TotalLiquidacion.Salud + TotalLiquidacion.Arl + TotalLiquidacion.Caja_Comp + TotalLiquidacion.ICBF + TotalLiquidacion.SENA;
                libroContable2.Haber = TotalLiquidacion.Pension;
                libroContable3.Haber = TotalLiquidacion.Cesantias + TotalLiquidacion.Int_Cesantias + TotalLiquidacion.Vacaciones + TotalLiquidacion.Prima;
                libroContable4.Haber = TotalLiquidacion.SalariosPagar;
                //Pendiente separcion de Gastos de personal
                libroContable5.Debe = TotalLiquidacion.Sueldo + TotalLiquidacion.SubTransporte + TotalLiquidacion.Comisiones + TotalLiquidacion.Salud_Empleador + TotalLiquidacion.Pension_Empleador + TotalLiquidacion.Arl +
                                    TotalLiquidacion.Parafiscales + TotalLiquidacion.Prima + TotalLiquidacion.Cesantias +
                                    TotalLiquidacion.Int_Cesantias + TotalLiquidacion.Vacaciones;
                _unitOfWork.LibroContableServiceRepository.Add(libroContable1);
                _unitOfWork.LibroContableServiceRepository.Add(libroContable2);
                _unitOfWork.LibroContableServiceRepository.Add(libroContable3);
                _unitOfWork.LibroContableServiceRepository.Add(libroContable4);
                _unitOfWork.LibroContableServiceRepository.Add(libroContable5);
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }
    }
}