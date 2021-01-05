import { Component, OnInit } from '@angular/core';
import {FacturasService} from './facturas.service';

@Component({
  selector: 'app-facturas',
  templateUrl: './facturas.component.html',
  styleUrls: ['./facturas.component.css']
})
export class FacturasComponent implements OnInit {

  facturas:IMFactura[];
  
  constructor(private facturasService: FacturasService) { }

  ngOnInit() {
    this.facturasService.getFacturas()
      .subscribe(factura => this.facturas = factura,
        error => console.error(error));

  }
 
}

export interface IMFactura{
   idMfactura:number,
   empleadoId :number,
   tercerosId :number,
   tipoMovimientoId :number,
   tipoMovimiento:string,
   fechaPago: Date, 
   subTotal :number,
   valorDevolucion :number,
   descuento :number,
   iVA :number,
   abono :number,
   estadoFactura: string,
   dFacturas: IDFactura[] 

}
export interface IDFactura{
  idDfactura:number,
  mfacturaId:number,
  referencia :string,
  promocionId :number,
  bodega :string,
  cantidad:number,
  precioUnitario:number
}
